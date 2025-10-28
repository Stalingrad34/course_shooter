using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Gameplay.ECS.Damage.Components;
using Leopotam.Ecs;
using Voody.UniLeo;

namespace Game.Scripts.Gameplay.ECS.Damage.Systems
{
  public class CollisionDamageSystem : IEcsRunSystem
  {
    private EcsFilter<CollisionDamageComponent, OnCollisionEnterEvent> _eventFilter;
    
    public void Run()
    {
      foreach (var i in _eventFilter)
      {
        var entity = _eventFilter.Get2(i).GameObject.GetComponent<ConvertToEntity>()?.TryGetEntity();
        if (entity.HasValue)
        {
          entity.Value.Get<DamageEvent>().Damage = _eventFilter.Get1(i).Damage;
        }
      }
    }
  }
}