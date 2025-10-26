using Game.Scripts.Gameplay.ECS.Input.Components;
using Game.Scripts.Gameplay.ECS.MouseRotate.Components;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.MouseRotate.Systems
{
  public class MouseHorizontalSystem : IEcsRunSystem
  {
    private EcsFilter<ControlComponent, MouseAngularVelocityComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        _filter.Get2(i).MouseDelta += _filter.Get1(i).MouseHorizontal;
      }
    }
  }
}