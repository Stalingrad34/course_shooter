using Game.Scripts.Gameplay.Data.Bullet;
using Game.Scripts.Gameplay.ECS.Input.Components;
using Game.Scripts.Gameplay.ECS.Weapon.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Weapon.Systems
{
  public class SpawnBulletSystem : IEcsRunSystem
  {
    private EcsFilter<WeaponComponent, SpawnBulletEvent> _weaponFilter;
    
    public void Run()
    {
      foreach (var i in _weaponFilter)
      {
        ref var weapon = ref _weaponFilter.Get1(i);
        var bullet = Object.Instantiate(weapon.BulletPrefab, _weaponFilter.Get2(i).Position, weapon.ShootPoint.rotation);

        var bulletData = new BulletData()
        {
          Direction = _weaponFilter.Get2(i).Direction
        };
        
        bullet.Setup(bulletData);
        weapon.Animator.SetTrigger("Shoot");
      }
    }
  }
}