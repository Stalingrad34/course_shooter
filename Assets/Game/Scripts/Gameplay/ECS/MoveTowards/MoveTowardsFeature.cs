using Game.Scripts.Gameplay.ECS.MoveTowards.Systems;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.MoveTowards
{
  public class MoveTowardsFeature : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
  {
    private EcsWorld _world;
    private EcsSystems _systems;

    public void Init()
    {
      _systems = new EcsSystems(_world);
      _systems
        .Add(new MoveTowardsSystem())
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