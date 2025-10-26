using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Gameplay.ECS.MouseRotate.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.MouseRotate.Systems
{
  public class LerpHorizontalRotateSystem : IEcsRunSystem
  {
    private EcsFilter<TransformComponent, LerpHorizontalRotateComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        _filter.Get1(i).Transform.localRotation = Quaternion.Lerp( _filter.Get1(i).Transform.localRotation,
          _filter.Get2(i).Rotation, _filter.Get2(i).Speed * Time.deltaTime);
      }
    }
  }
}