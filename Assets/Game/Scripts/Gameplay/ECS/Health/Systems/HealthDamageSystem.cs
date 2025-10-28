using Game.Scripts.Gameplay.ECS.Damage.Components;
using Game.Scripts.Gameplay.ECS.Health.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Health.Systems
{
  public class HealthDamageSystem : IEcsRunSystem
  {
    private EcsFilter<HealthComponent, DamageEvent> _eventFilter;
    
    public void Run()
    {
      foreach (var i in _eventFilter)
      {
        _eventFilter.Get1(i).CurrentHealth = Mathf.Max(_eventFilter.Get1(i).CurrentHealth - _eventFilter.Get2(i).Damage, 0);
      }
    }
  }
}