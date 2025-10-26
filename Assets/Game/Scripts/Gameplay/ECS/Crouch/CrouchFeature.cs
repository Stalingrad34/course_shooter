using Game.Scripts.Gameplay.ECS.Crouch.Systems;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Crouch
{
  public class CrouchFeature : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
  {
    private EcsWorld _world;
    private EcsSystems _systems;

    public void Init()
    {
      _systems = new EcsSystems(_world);
      _systems
        .Add(new ChangesCrouchSystem())
        .Add(new KeyCrouchSystem())
        .Add(new CrouchSystem())
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