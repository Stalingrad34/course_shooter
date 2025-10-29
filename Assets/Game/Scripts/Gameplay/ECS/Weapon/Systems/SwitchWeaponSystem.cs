using System.Collections.Generic;
using Game.Scripts.Gameplay.Data.Units;
using Game.Scripts.Gameplay.ECS.Input.Components;
using Game.Scripts.Gameplay.ECS.Weapon.Components;
using Game.Scripts.Multiplayer;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Weapon.Systems
{
  public class SwitchWeaponSystem : IEcsRunSystem
  {
    private EcsFilter<ControlComponent, WeaponComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        if (_filter.Get1(i).Alpha1KeyDown)
        {
          _filter.Get2(i).Weapons.ForEach(go => go.gameObject.SetActive(false));
          _filter.Get2(i).Weapons[0].SetActive(true);
          
          var data = new Dictionary<string, object>(){
            ["weapon"] = (ushort)WeaponType.Weapon1
          };
          
          MultiplayerManager.Instance.SendMessage("weapon", data);
        }
        
        if (_filter.Get1(i).Alpha2KeyDown)
        {
          _filter.Get2(i).Weapons.ForEach(go => go.gameObject.SetActive(false));
          _filter.Get2(i).Weapons[1].SetActive(true);
          
          var data = new Dictionary<string, object>(){
            ["weapon"] = (ushort)WeaponType.Weapon2 
          };
          
          MultiplayerManager.Instance.SendMessage("weapon", data);
        }
      }
    }
  }
}