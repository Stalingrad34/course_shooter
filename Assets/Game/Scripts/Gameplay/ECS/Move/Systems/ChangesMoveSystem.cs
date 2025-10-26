using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Gameplay.ECS.Move.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Move.Systems
{
  public class ChangesMoveSystem : IEcsRunSystem
  {
    private EcsFilter<IdentifierComponent, ServerPlayerComponent, MoveTowardsComponent> _serverPlayers;
    private EcsFilter<PlayerChangeEvent> _eventFilter;
    
    public void Run()
    {
      foreach (var i in _eventFilter)
      {
        foreach (var ii in _serverPlayers)
        {
          if (_serverPlayers.Get1(ii).Id != _eventFilter.Get1(i).Id)
            continue;
          
          var destination = _serverPlayers.Get3(ii).Destination;
          var velocity = _serverPlayers.Get3(ii).Velocity;
          foreach (var change in _eventFilter.Get1(i).Changes)
          {
            switch (change.Field)
            {
              case "pX":
                destination.x = (float)change.Value;
                break;
              case "pY":
                destination.y = (float)change.Value;
                break;
              case "pZ":
                destination.z = (float)change.Value;
                break;
              case "vX":
                velocity.x = (float)change.Value;
                break;
              case "vY":
                velocity.y = (float)change.Value;
                break;
              case "vZ":
                velocity.z = (float)change.Value;
                break;
            }
          }
          
          _serverPlayers.Get3(ii).Destination = destination + velocity * _eventFilter.Get1(i).AverageInterval;
          _serverPlayers.Get3(ii).Velocity = velocity;
        }
      }
    }
  }
}