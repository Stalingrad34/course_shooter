using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Gameplay.ECS.Move.Components;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Move.Systems
{
  public class ChangesMoveSystem : IEcsRunSystem
  {
    private EcsFilter<IdentifierComponent, ServerPlayerComponent, MoveableComponent> _serverPlayers;
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
          foreach (var change in _eventFilter.Get1(i).Changes)
          {
            switch (change.Field)
            {
              case "x":
                destination.x = (float)change.Value;
                break;
              case "y":
                destination.z = (float)change.Value;
                break;
            }
          }
      
          _serverPlayers.Get3(ii).Destination = destination;
        }
      }
    }
  }
}