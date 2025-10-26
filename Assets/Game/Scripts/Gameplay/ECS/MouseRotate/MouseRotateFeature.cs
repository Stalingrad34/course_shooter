using Game.Scripts.Gameplay.ECS.MouseRotate.Systems;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.MouseRotate
{
  public class MouseRotateFeature : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
  {
    private EcsWorld _world;
    private EcsSystems _systems;

    public void Init()
    {
      _systems = new EcsSystems(_world);
      _systems
        .Add(new MouseHorizontalSystem())
        .Add(new MouseVerticalSystem())
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