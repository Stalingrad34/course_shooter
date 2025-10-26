using Game.Scripts.Gameplay.ECS.SendMessage.Components;
using Game.Scripts.Multiplayer;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.SendMessage.Systems
{
  public class SendMessageSystem : IEcsRunSystem
  {
    private EcsFilter<SendDataComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        MultiplayerManager.Instance.SendMessage("move", _filter.Get1(i).SendData);
      }
    }
  }
}