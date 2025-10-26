using Game.Scripts.Gameplay.Data.Units;
using Game.Scripts.Gameplay.ECS.Spawn.Components;
using Game.Scripts.Infrastructure;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Spawn.Systems
{
  public class SpawnPlayerSystem : IEcsRunSystem
  {
    private EcsFilter<SpawnPlayerEvent> _eventFilter;
    private Camera _mainCamera;
    
    public void Run()
    {
      foreach (var i in _eventFilter)
      {
        var data = new UnitData()
        {
          Id = _eventFilter.Get1(i).Id
        };
        
        var unitView = AssetProvider.GetPlayerView();
        unitView.SetCameraPoint(_mainCamera);
        
        unitView.Setup(data);
        unitView.transform.position = _eventFilter.Get1(i).Position;
      }
    }
  }
}