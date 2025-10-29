using System.Collections.Generic;
using Game.Scripts.Gameplay.Data.Bullet;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Weapon.Components
{
  public struct WeaponComponent
  {
    public BulletView BulletPrefab;
    public Transform ShootPoint;
    public Animator Animator;
    public float ShootDelay;
    public float ShootTimer;
    public bool CanShoot;
    public List<GameObject> Weapons;
  }
}