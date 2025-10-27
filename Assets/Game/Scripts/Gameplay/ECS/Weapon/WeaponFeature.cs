using Game.Scripts.Gameplay.ECS.Weapon.Components;
using Game.Scripts.Gameplay.ECS.Weapon.Systems;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Weapon
{
  public class WeaponFeature : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
  {
    private EcsWorld _world;
    private EcsSystems _systems;

    public void Init()
    {
      _systems = new EcsSystems(_world);
      _systems
        .Add(new MessageShootSystem())
        .Add(new ShootDelaySystem())
        .Add(new MouseShootSystem())
        .Add(new SpawnBulletSystem())
        .OneFrame<SpawnBulletEvent>()
        .OneFrame<MessageShootEvent>()
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