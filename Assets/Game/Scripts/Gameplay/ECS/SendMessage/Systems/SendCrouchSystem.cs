using Game.Scripts.Gameplay.ECS.Crouch.Components;
using Game.Scripts.Gameplay.ECS.SendMessage.Components;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.SendMessage.Systems
{
  public class SendCrouchSystem : IEcsRunSystem
  {
    private EcsFilter<SendDataComponent, CrouchComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        _filter.Get1(i).SendData["cr"] = _filter.Get2(i).IsCrouch;
      }
    }
  }
}