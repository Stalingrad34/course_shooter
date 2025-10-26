using Game.Scripts.Gameplay.ECS.Crouch.Components;
using Game.Scripts.Gameplay.ECS.Input.Components;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Crouch.Systems
{
  public class KeyCrouchSystem : IEcsRunSystem
  {
    private EcsFilter<ControlComponent, CrouchComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        _filter.Get2(i).IsCrouch = _filter.Get1(i).CtrlKeyDown;
      }
    }
  }
}