using System.Collections.Generic;
using Game.Scripts.Gameplay.ECS.Input.Components;
using Game.Scripts.Gameplay.ECS.Move.Components;
using Game.Scripts.Multiplayer;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Move.Systems
{
  public class SendMoveSystem : IEcsRunSystem
  {
    private EcsFilter<ControlComponent, TransformComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        var position = _filter.Get2(i).Transform.position;
        var data = new Dictionary<string, object>()
        {
          {"x", position.x},
          {"y", position.z},
        };
      
        MultiplayerManager.Instance.SendMessage("move", data);
      }
    }
  }
}