using Game.Scripts.Gameplay.Data.Bullet;
using Game.Scripts.Gameplay.Data.Units;
using Game.Scripts.Gameplay.ECS.Rigidbody.Components;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Game.Scripts.Gameplay.ECS.Converters
{
  public class MoveVelocityConverter : MonoBehaviour, IConvertToEntity, IUnitSetup, IBulletSetup
  {
    [SerializeField] private float speed;
    private Vector3 _velocity;
    
    public void Convert(EcsEntity entity)
    {
      entity.Get<MoveVelocityComponent>().Speed = speed;
      entity.Get<MoveVelocityComponent>().Velocity = _velocity;
    }

    public void Setup(UnitData data)
    {
      speed = data.Speed;
    }

    public void Setup(BulletData data)
    {
      _velocity = data.Direction * speed;
    }
  }
}