using Game.Scripts.Gameplay.Data.Bullet;
using Game.Scripts.Gameplay.ECS.Weapon.Components;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Game.Scripts.Gameplay.ECS.Converters
{
  public class WeaponConverter : MonoBehaviour, IConvertToEntity
  {
    [SerializeField] private BulletView bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Animator animator;
    [SerializeField] private float shootDelay;
    
    public void Convert(EcsEntity entity)
    {
      ref var component = ref entity.Get<WeaponComponent>();
      component.BulletPrefab = bulletPrefab;
      component.ShootPoint = shootPoint;
      component.Animator = animator;
      component.ShootDelay = shootDelay;
      component.ShootTimer = shootDelay;
    }
  }
}