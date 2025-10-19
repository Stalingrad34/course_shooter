using Game.Scripts.Gameplay.ECS.Input.Components;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Input.Systems
{
  public class AxisSystem : IEcsRunSystem
  {
    private EcsFilter<ControlComponent> _filter;
    
    public void Run()
    {
      var horizontal = UnityEngine.Input.GetAxis("Horizontal");
      var vertical = UnityEngine.Input.GetAxis("Vertical");
      
      foreach (var i in _filter)
      {
        _filter.Get1(i).HorizontalAxis = horizontal;
        _filter.Get1(i).VerticalAxis = vertical;
      }
    }
  }
}