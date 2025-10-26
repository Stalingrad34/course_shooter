using Game.Scripts.Gameplay.ECS.MouseRotate.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.MouseRotate.Systems
{
  public class LerpVerticalRotateSystem : IEcsRunSystem
  {
    private EcsFilter<LerpVerticalRotateComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        _filter.Get1(i).Target.localRotation = Quaternion.Lerp(_filter.Get1(i).Target.localRotation,
          _filter.Get1(i).Rotation, _filter.Get1(i).Speed * Time.deltaTime);
      }
    }
  }
}