using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Gameplay.ECS.Crouch.Components;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Crouch.Systems
{
  public class ChangesCrouchSystem : IEcsRunSystem
  {
    private EcsFilter<IdentifierComponent, ServerPlayerComponent, CrouchComponent> _serverPlayers;
    private EcsFilter<PlayerChangeEvent> _eventFilter;
    
    public void Run()
    {
      foreach (var i in _eventFilter)
      {
        foreach (var ii in _serverPlayers)
        {
          if (_serverPlayers.Get1(ii).Id != _eventFilter.Get1(i).Id)
            continue;
          
          foreach (var change in _eventFilter.Get1(i).Changes)
          {
            if (change.Field.Equals("cr"))
            {
              _serverPlayers.Get3(i).IsCrouch = (bool) change.Value;
            }
          }
        }
      }
    }
  }
}