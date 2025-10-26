using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Gameplay.ECS.MouseRotate.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.MouseRotate.Systems
{
  public class ChangesVerticalRotateSystem : IEcsRunSystem
  {
    private EcsFilter<IdentifierComponent, ServerPlayerComponent, LerpVerticalRotateComponent> _serverPlayers;
    private EcsFilter<PlayerChangeEvent> _eventFilter;
    
    public void Run()
    {
      foreach (var i in _eventFilter)
      {
        foreach (var ii in _serverPlayers)
        {
          if (_serverPlayers.Get1(ii).Id != _eventFilter.Get1(i).Id)
            continue;
          
          var rotateX = _serverPlayers.Get3(ii).Target.localEulerAngles;
          foreach (var change in _eventFilter.Get1(i).Changes)
          {
            switch (change.Field)
            {
              case "rX":
                rotateX.x = (float)change.Value;
                break;
            }
          }

          _serverPlayers.Get3(ii).Rotation = Quaternion.Euler(rotateX);
        }
      }
    }
  }
}