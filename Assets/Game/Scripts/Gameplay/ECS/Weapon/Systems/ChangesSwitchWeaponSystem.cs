using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Gameplay.ECS.Weapon.Components;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Weapon.Systems
{
  public class ChangesSwitchWeaponSystem : IEcsRunSystem
  {
    private EcsFilter<IdentifierComponent, WeaponComponent> _filter;
    private EcsFilter<PlayerChangeEvent> _eventFilter;
    
    public void Run()
    {
      foreach (var i in _eventFilter)
      {
        foreach (var ii in _filter)
        {
          if (_filter.Get1(ii).Id != _eventFilter.Get1(i).Id)
            continue;
          
          foreach (var change in _eventFilter.Get1(i).Changes)
          {
            if (change.Field.Equals("weapon"))
            {
              _filter.Get2(ii).Weapons.ForEach(go => go.gameObject.SetActive(false));
              _filter.Get2(ii).Weapons[(ushort)change.Value].gameObject.SetActive(true);
            }
          }
        }
      }
    }
  }
}