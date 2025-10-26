using System.Collections.Generic;
using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Gameplay.ECS.Input.Components;
using Game.Scripts.Multiplayer;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.SendMessage.Systems
{
  public class SendMoveSystem : IEcsRunSystem
  {
    private EcsFilter<ControlComponent, RigidbodyComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        var rigidbody = _filter.Get2(i).Rigidbody;
        var data = new Dictionary<string, object>()
        {
          {"pX", rigidbody.position.x},
          {"pY", rigidbody.position.y},
          {"pZ", rigidbody.position.z},
          {"vX", rigidbody.linearVelocity.z},
          {"vY", rigidbody.linearVelocity.z},
          {"vZ", rigidbody.linearVelocity.z},
        };
      
        MultiplayerManager.Instance.SendMessage("move", data);
      }
    }
  }
}