using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.MoveTowards.Components
{
  public struct MoveTowardsComponent
  {
    public Vector3 Destination;
    public float VelocityMagnitude;
    public float Speed;
  }
}