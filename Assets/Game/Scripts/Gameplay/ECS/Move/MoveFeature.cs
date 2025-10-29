using Game.Scripts.Gameplay.ECS.Move.Systems;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Move
{
  public class MoveFeature : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
  {
    private EcsWorld _world;
    private EcsSystems _systems;

    public void Init()
    {
      _systems = new EcsSystems(_world);
      _systems
        .Add(new ChangesMoveSystem())
        .Add(new AxisMoveVelocitySystem())
        .Add(new MoveTowardsSystem())
        .Add(new MoveVelocityAnimationSystem())
        .Add(new MoveTowardsAnimationSystem())
        .Add(new RestartVelocitySystem())
        .Add(new RestartTowardsSystem())
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