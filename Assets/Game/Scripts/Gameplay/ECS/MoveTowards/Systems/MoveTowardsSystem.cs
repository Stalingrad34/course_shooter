using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Gameplay.ECS.MoveTowards.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.MoveTowards.Systems
{
  public class MoveTowardsSystem : IEcsRunSystem
  {
    private EcsFilter<TransformComponent, MoveTowardsComponent> _moveableFilter;
    
    public void Run()
    {
      foreach (var i in _moveableFilter)
      {
        var transform = _moveableFilter.Get1(i).Transform;
        var destination = _moveableFilter.Get2(i).Destination;
        var velocityMagnitude = _moveableFilter.Get2(i).VelocityMagnitude;

        if (Mathf.Approximately(velocityMagnitude, 0f))
        {
          transform.position = destination;
        }
        else
        {
          transform.position = Vector3.MoveTowards(
            transform.position, 
            destination, 
            velocityMagnitude * Time.deltaTime
          );
        }
      }
    }
  }
}