using Game.Scripts.Gameplay.ECS.Common;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Game.Scripts.Gameplay.ECS.Converters
{
  public class AnimatorConverter : MonoBehaviour, IConvertToEntity
  {
    [SerializeField] private Animator animator;
    
    public void Convert(EcsEntity entity)
    {
      entity.Get<AnimatorComponent>().Animator = animator;
    }
  }
}