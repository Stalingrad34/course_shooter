using Game.Scripts.Gameplay.ECS.Spawn.Components;
using Game.Scripts.Gameplay.ECS.Spawn.Systems;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Spawn
{
  public class SpawnFeature : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
  {
    private EcsWorld _world;
    private EcsSystems _systems;

    public void Init()
    {
      _systems = new EcsSystems(_world);
      _systems
        .Add(new SpawnUnitSystem())
        .OneFrame<SpawnUnitEvent>()
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