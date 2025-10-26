using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Gameplay.ECS.MouseRotate.Components;
using Game.Scripts.Gameplay.ECS.SendMessage.Components;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.SendMessage.Systems
{
  public class SendRotateDataSystem : IEcsRunSystem
  {
    private EcsFilter<SendDataComponent, TransformComponent, MouseTransformRotateComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        _filter.Get1(i).SendData["rX"] = _filter.Get3(i).Target.localEulerAngles.x;
        _filter.Get1(i).SendData["rY"] = _filter.Get2(i).Transform.localEulerAngles.y;
      }
    }
  }
}