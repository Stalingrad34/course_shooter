using Game.Scripts.Gameplay.Data.Units;
using Game.Scripts.Gameplay.ECS.Spawn.Components;
using Game.Scripts.Infrastructure;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Spawn.Systems
{
  public class SpawnUnitSystem : IEcsRunSystem
  {
    private EcsFilter<SpawnUnitEvent> _eventFilter;
    
    public void Run()
    {
      foreach (var i in _eventFilter)
      {
        var data = new UnitData()
        {
          Id = _eventFilter.Get1(i).Id
        };

        UnitView unitView;
        if (_eventFilter.Get1(i).IsPlayer)
          unitView = AssetProvider.GetPlayerView();
        else
          unitView = AssetProvider.GetEnemyView();
        
        unitView.Setup(data);
        unitView.transform.position = _eventFilter.Get1(i).Position;
      }
    }
  }
}