using Game.Scripts.Gameplay.ECS.Input.Components;
using Game.Scripts.Gameplay.ECS.MouseRotate.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.MouseRotate.Systems
{
  public class MouseVerticalSystem: IEcsRunSystem
  {
    private EcsFilter<ControlComponent, MouseTransformRotateComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        var mouseY = _filter.Get1(i).MouseVertical;
        var sensitivity = _filter.Get2(i).Speed;
        var minAngle = _filter.Get2(i).MinAngle;
        var maxAngle = _filter.Get2(i).MaxAngle;

        var angle = -mouseY * sensitivity;
        var rotateX = _filter.Get2(i).CurrentAngle;
        rotateX = Mathf.Clamp(rotateX + angle, minAngle, maxAngle);
        _filter.Get2(i).CurrentAngle = rotateX;
        
        _filter.Get2(i).Target.localEulerAngles = new Vector3(rotateX, 0, 0);
      }
    }
  }
}