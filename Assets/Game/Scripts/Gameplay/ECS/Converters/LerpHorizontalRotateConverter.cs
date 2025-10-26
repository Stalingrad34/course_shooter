using Game.Scripts.Gameplay.ECS.MouseRotate.Components;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Game.Scripts.Gameplay.ECS.Converters
{
  public class LerpHorizontalRotateConverter : MonoBehaviour, IConvertToEntity
  {
    [SerializeField] private float speed;
    
    public void Convert(EcsEntity entity)
    {
      entity.Get<LerpHorizontalRotateComponent>().Speed = speed;
    }
  }
}