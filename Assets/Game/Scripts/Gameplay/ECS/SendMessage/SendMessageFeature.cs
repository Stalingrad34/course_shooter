using Game.Scripts.Gameplay.ECS.SendMessage.Systems;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.SendMessage
{
  public class SendMessageFeature : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
  {
    private EcsWorld _world;
    private EcsSystems _systems;

    public void Init()
    {
      _systems = new EcsSystems(_world);
      _systems
        .Add(new SendRotateDataSystem())
        .Add(new SendMoveSystem())
        .Add(new SendCrouchSystem())
        .Add(new SendMessageSystem())
        .Init();
    }

    public void Run()
    {
      _systems?.Run();
    }

    public void Destroy()
    {
      _systems?.Destroy();
    }
  }
}