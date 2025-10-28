using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Common
{
  public struct OnCollisionEnterEvent
  {
    public Collision Collision;
    public GameObject GameObject;
  }
}