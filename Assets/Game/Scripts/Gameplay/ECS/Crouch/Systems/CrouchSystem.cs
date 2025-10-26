using Game.Scripts.Gameplay.ECS.Crouch.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Crouch.Systems
{
  public class CrouchSystem : IEcsRunSystem
  {
    private EcsFilter<CrouchComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        var crouchPosition = _filter.Get1(i).IsCrouch 
          ? new Vector3(0, 0, _filter.Get1(i).CrouchPosY) 
          : Vector3.zero;

        _filter.Get1(i).CrouchRoot.localPosition = crouchPosition;
      }
    }
  }
}