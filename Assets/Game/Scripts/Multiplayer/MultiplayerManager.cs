using System;
using System.Collections.Generic;
using Colyseus;
using Cysharp.Threading.Tasks;
using Game.Scripts.Gameplay.Data.Units;
using Game.Scripts.Infrastructure;
using Game.Scripts.Infrastructure.Services;
using Newtonsoft.Json;

namespace Game.Scripts.Multiplayer
{
  public class MultiplayerManager : ColyseusManager<MultiplayerManager>, IService
  {
    public event Action<string, Player> OnPlayerConnected;
    public event Action<string, Player> OnPlayerDisconnected;
    public event Action<ShootInfo> OnShootMessageReceived;
    
    private readonly Dictionary<string, PlayerChangesHandler> _changesHandlers = new();
    private ColyseusRoom<State> _room;
    
    public void Init()
    {
      Instance.InitializeClient();

#if UNITY_EDITOR
      ApplicationLifecycleProvider.ApplicationQuit += Disconnect;
#endif
    }

    public async UniTaskVoid Connect(PlayerData playerData)
    {
      var data = new Dictionary<string, object>()
      {
        {"speed", playerData.Speed},
        {"health", playerData.Health},
      };
      _room = await Instance.client.JoinOrCreate<State>("state_handler", data).AsUniTask();
      
      _room.OnStateChange += OnChange;
      _room.State.players.OnAdd += OnPlayerAdd;
      _room.State.players.OnRemove += OnPlayerRemove;
      _room.State.players.ForEach(OnPlayerAdd);
      _room.OnMessage<string>("Shoot", OnShootMessage);
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
      _changesHandlers.Add(key, handler);
      OnPlayerConnected?.Invoke(key, player);
    }
    
    private void OnPlayerRemove(string key, Player player)
    {
      _changesHandlers.Remove(key);
      OnPlayerDisconnected?.Invoke(key, player);
    }

    private void OnChange(State state, bool isFirstState)
    {
      
    }

    private void OnShootMessage(string message)
    {
      var shootInfo = JsonConvert.DeserializeObject<ShootInfo>(message);
      OnShootMessageReceived?.Invoke(shootInfo);
    }

    public void SendMessage(string key, Dictionary<string, object> data)
    {
      _room.Send(key, data);
    }
    
    public void SendMessage(string key, string data)
    {
      _room.Send(key, data);
    }

    public void SendShootMessage(ShootInfo shootInfo)
    {
      shootInfo.key = _room.SessionId;
      var json = JsonConvert.SerializeObject(shootInfo);
      SendMessage("shoot", json);
    }
    
    public void SendDamageMessage(string key, int damage)
    {
      var data = new Dictionary<string, object>()
      {
        {"id", key},
        {"value", damage}
      };
      
      SendMessage("damage", data);
    }
  }
}
