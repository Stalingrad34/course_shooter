using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Gameplay.ECS.MouseRotate.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.MouseRotate.Systems
{
  public class ChangesHorizontalRotateSystem : IEcsRunSystem
  {
    private EcsFilter<IdentifierComponent, ServerPlayerComponent, TransformComponent, LerpHorizontalRotateComponent> _serverPlayers;
    private EcsFilter<PlayerChangeEvent> _eventFilter;
    
    public void Run()
    {
      foreach (var i in _eventFilter)
      {
        foreach (var ii in _serverPlayers)
        {
          if (_serverPlayers.Get1(ii).Id != _eventFilter.Get1(i).Id)
            continue;
          
          var rotateY = _serverPlayers.Get3(ii).Transform.localEulerAngles;
          foreach (var change in _eventFilter.Get1(i).Changes)
          {
            switch (change.Field)
            {
              case "rY":
                rotateY.y = (float)change.Value;
                break;
            }
          }
          
          _serverPlayers.Get4(ii).Rotation = Quaternion.Euler(rotateY);
        }
      }
    }
  }
}