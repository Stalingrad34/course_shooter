using Game.Scripts.Gameplay.ECS.PlayerChange.Components;
using Game.Scripts.Gameplay.ECS.PlayerChange.Systems;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.PlayerChange
{
  public class PlayerChangeFeature : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
  {
    private EcsWorld _world;
    private EcsSystems _systems;

    public void Init()
    {
      _systems = new EcsSystems(_world);
      _systems
        .Add(new ChangesMoveSystem())
        .OneFrame<PlayerChangeEvent>()
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