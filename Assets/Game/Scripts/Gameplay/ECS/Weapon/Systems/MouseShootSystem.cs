using Game.Scripts.Gameplay.ECS.Input.Components;
using Game.Scripts.Gameplay.ECS.Weapon.Components;
using Game.Scripts.Multiplayer;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Weapon.Systems
{
  public class MouseShootSystem : IEcsRunSystem
  {
    private EcsFilter<ControlComponent, WeaponComponent> _weaponFilter;
    
    public void Run()
    {
      foreach (var i in _weaponFilter)
      {
        if (!_weaponFilter.Get2(i).CanShoot || !_weaponFilter.Get1(i).MouseLeftClicked)
          continue;

        var position = _weaponFilter.Get2(i).ShootPoint.position;
        var direction = _weaponFilter.Get2(i).ShootPoint.forward;
        
        ref var spawnEvent = ref _weaponFilter.GetEntity(i).Get<SpawnBulletEvent>();
        spawnEvent.Position = position;
        spawnEvent.Direction = direction;
        _weaponFilter.Get2(i).ShootTimer = 0;

        var shootInfo = new ShootInfo()
        {
          pX = position.x,
          pY = position.y,
          pZ = position.z,
          dX = direction.x,
          dY = direction.y,
          dZ = direction.z
        };
        
        MultiplayerManager.Instance.SendShootMessage(shootInfo);
      }
    }
  }
}