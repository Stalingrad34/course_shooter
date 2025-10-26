using Game.Scripts.Gameplay.ECS.Crouch.Components;
using Game.Scripts.Gameplay.ECS.Move.Components;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Game.Scripts.Gameplay.ECS.Converters
{
  public class CrouchConverter : MonoBehaviour, IConvertToEntity
  {
    [SerializeField] private Transform crouchRoot;
    [SerializeField] private float crouchPosY;
    
    public void Convert(EcsEntity entity)
    {
      entity.Get<CrouchComponent>().CrouchRoot = crouchRoot;
      entity.Get<CrouchComponent>().CrouchPosY = crouchPosY;
    }
  }
}