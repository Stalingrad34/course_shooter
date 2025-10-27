using Cysharp.Threading.Tasks;
using Game.Scripts.Gameplay.ECS.Spawn.Components;
using Game.Scripts.Gameplay.ECS.Weapon.Components;
using Game.Scripts.Infrastructure.Services;
using Game.Scripts.Multiplayer;
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
      _multiplayer.OnShootMessageReceived += OnShootMessageReceived;
      _multiplayer.Connect().Forget();
    }

    private void OnPlayerConnected(string key, Player player)
    {
      if (_multiplayer.IsPlayer(key))
      {
        ref var spawnEvent = ref WorldHandler.GetWorld().NewEntity().Get<SpawnPlayerEvent>();
        spawnEvent.Id = key;
        spawnEvent.Position = new Vector3(player.pX, player.pY, player.pZ);
      }
      else
      {
        ref var spawnEvent = ref WorldHandler.GetWorld().NewEntity().Get<SpawnEnemyEvent>();
        spawnEvent.Id = key;
        spawnEvent.Position = new Vector3(player.pX, player.pY, player.pZ);
        spawnEvent.Player = player;
      }
    }

    private void OnPlayerDisconnected(string key, Player player)
    {
      
    }

    private void OnShootMessageReceived(ShootInfo shootInfo)
    {
      WorldHandler.GetWorld().NewEntity().Get<MessageShootEvent>().ShootInfo = shootInfo;
    }

    public void Exit()
    {
      _multiplayer.OnPlayerConnected -= OnPlayerConnected;
      _multiplayer.OnPlayerDisconnected -= OnPlayerDisconnected;
      _multiplayer.OnShootMessageReceived -= OnShootMessageReceived;
      _multiplayer.Disconnect();
    }
  }
}