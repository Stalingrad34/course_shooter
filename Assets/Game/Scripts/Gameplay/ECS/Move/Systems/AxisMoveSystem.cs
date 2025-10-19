﻿using Game.Scripts.Gameplay.ECS.Input.Components;
using Game.Scripts.Gameplay.ECS.Move.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Move.Systems
{
  public class AxisMoveSystem : IEcsRunSystem
  {
    private EcsFilter<ControlComponent, TransformComponent, MoveableComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        var horizontal = _filter.Get1(i).HorizontalAxis;
        var vertical = _filter.Get1(i).VerticalAxis;

        var direction = new Vector3(horizontal, 0, vertical).normalized;
        _filter.Get3(i).Destination = _filter.Get2(i).Transform.position + direction;
      }
    }
  }
}