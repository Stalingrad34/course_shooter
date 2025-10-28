using Game.Scripts.Gameplay.ECS.Health.Systems;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Health
{
  public class HealthFeature : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
  {
    private EcsWorld _world;
    private EcsSystems _systems;

    public void Init()
    {
      _systems = new EcsSystems(_world);
      _systems
        .Add(new HealthDamageSystem())
        .Add(new HealthHUDSystem())
        .Add(new HealthDeadSystem())
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