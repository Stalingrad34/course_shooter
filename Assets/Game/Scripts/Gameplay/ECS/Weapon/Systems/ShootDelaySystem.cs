using Game.Scripts.Gameplay.ECS.Weapon.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Weapon.Systems
{
  public class ShootDelaySystem : IEcsRunSystem
  {
    private EcsFilter<WeaponComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        _filter.Get1(i).ShootTimer += Time.deltaTime;
        _filter.Get1(i).CanShoot = _filter.Get1(i).ShootTimer > _filter.Get1(i).ShootDelay;
      }
    }
  }
}