using Cysharp.Threading.Tasks;
using Game.Scripts.Gameplay.ECS.Spawn.Components;
using Game.Scripts.Infrastructure.Services;
using Game.Scripts.Multiplayer;
using Game.Scripts.Multiplayer.Generated;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.SceneManagement;
using Voody.UniLeo;

namespace Game.Scripts.Infrastructure.States
{
  public class MainState : IEnterStateAsync, IExitState
  {
    private MultiplayerManager _multiplayer;

    public async UniTask Enter()
    {
      await SceneManager.LoadSceneAsync("Battle");

      _multiplayer = ServiceProvider.Get<MultiplayerManager>();
      _multiplayer.OnPlayerConnected += OnPlayerConnected;
      _multiplayer.OnPlayerDisconnected += OnPlayerDisconnected;
      _multiplayer.Connect().Forget();
    }

    private void OnPlayerConnected(string key, Player player)
    {
      ref var spawnEvent = ref WorldHandler.GetWorld().NewEntity().Get<SpawnUnitEvent>();
      spawnEvent.Id = key;
      spawnEvent.Position = new Vector3(player.x, 0,  player.y);
      spawnEvent.IsPlayer = _multiplayer.IsPlayer(key);
    }

    private void OnPlayerDisconnected(string key, Player player)
    {
      
    }

    public void Exit()
    {
      _multiplayer.OnPlayerConnected -= OnPlayerConnected;
      _multiplayer.OnPlayerDisconnected -= OnPlayerDisconnected;
      _multiplayer.Disconnect();
    }
  }
}