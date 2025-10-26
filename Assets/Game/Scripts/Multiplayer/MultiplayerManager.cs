using System;
using System.Collections.Generic;
using Colyseus;
using Cysharp.Threading.Tasks;
using Game.Scripts.Infrastructure;
using Game.Scripts.Infrastructure.Services;

namespace Game.Scripts.Multiplayer
{
  public class MultiplayerManager : ColyseusManager<MultiplayerManager>, IService
  {
    public event Action<string, Player> OnPlayerConnected;
    public event Action<string, Player> OnPlayerDisconnected;
    
    private List<PlayerChangesHandler> _changesHandlers = new ();
    private ColyseusRoom<State> _room;
    
    public void Init()
    {
      Instance.InitializeClient();

#if UNITY_EDITOR
      ApplicationLifecycleProvider.ApplicationQuit += Disconnect;
#endif
    }

    public async UniTaskVoid Connect()
    {
      var data = new Dictionary<string, object>()
      {
        {"speed", 2}
      };
      _room = await Instance.client.JoinOrCreate<State>("state_handler", data).AsUniTask();
      
      _room.OnStateChange += OnChange;
      _room.State.players.OnAdd += OnPlayerAdd;
      _room.State.players.OnRemove += OnPlayerRemove;
      _room.State.players.ForEach(OnPlayerAdd);
    }
    
    public void Disconnect()
    {
      if (_room == null)
        return;
      
      _room.OnStateChange -= OnChange;
      _room.State.players.OnAdd -= OnPlayerAdd;
      _room.State.players.OnRemove -= OnPlayerRemove;
      
      _room.Leave().AsUniTask().Forget();
      _changesHandlers.Clear();
    }

    public bool IsPlayer(string key)
    {
      return key.Equals(_room?.SessionId);
    }

    private void OnPlayerAdd(string key, Player player)
    {
      var handler = new PlayerChangesHandler(key);
      player.OnChange += handler.OnPlayerChanged;
      _changesHandlers.Add(handler);
      OnPlayerConnected?.Invoke(key, player);
    }
    
    private void OnPlayerRemove(string key, Player player)
    {
      OnPlayerDisconnected?.Invoke(key, player);
    }

    private void OnChange(State state, bool isFirstState)
    {
      
    }

    public void SendMessage(string key, Dictionary<string, object> data)
    {
      _room.Send(key, data);
    }
  }
}
