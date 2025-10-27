using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Gameplay.ECS.Weapon.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Weapon.Systems
{
  public class MessageShootSystem : IEcsRunSystem
  {
    private EcsFilter<IdentifierComponent> _filter;
    private EcsFilter<MessageShootEvent> _eventFilter;
    
    public void Run()
    {
      foreach (var i in _eventFilter)
      {
        foreach (var ii in _filter)
        {
          if (_filter.Get1(ii).Id != _eventFilter.Get1(i).ShootInfo.key)
            continue;
          
          var shootInfo =  _eventFilter.Get1(i).ShootInfo;
          var position = new Vector3(shootInfo.pX, shootInfo.pY, shootInfo.pZ);
          var direction = new Vector3(shootInfo.dX, shootInfo.dY, shootInfo.dZ);
          
          ref var spawnEvent = ref _filter.GetEntity(ii).Get<SpawnBulletEvent>();
          spawnEvent.Position = position;
          spawnEvent.Direction = direction;
        }
      }
    }
  }
}