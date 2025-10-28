﻿using Game.Scripts.Gameplay.ECS.Health.Components;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Health.Systems
{
  public class HealthHUDSystem : IEcsRunSystem
  {
    private EcsFilter<HealthComponent> _healthFilter;
    
    public void Run()
    {
      foreach (var i in _healthFilter)
      {
        var current = _healthFilter.Get1(i).CurrentHealth;
        var max  = _healthFilter.Get1(i).MaxHealth;
        _healthFilter.Get1(i).ProgressBar.fillAmount = (float)current / max;
      }
    }
  }
}