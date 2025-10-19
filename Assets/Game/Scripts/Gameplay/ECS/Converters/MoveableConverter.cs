using Game.Scripts.Gameplay.ECS.Move.Components;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Game.Scripts.Gameplay.ECS.Converters
{
  public class MoveableConverter : MonoBehaviour, IConvertToEntity
  {
    [SerializeField] private float speed;
    
    public void Convert(EcsEntity entity)
    {
      entity.Get<MoveableComponent>().Destination = transform.position;
      entity.Get<MoveableComponent>().Speed = speed;
    }
  }
}