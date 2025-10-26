using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.MouseRotate.Components
{
  public struct LerpVerticalRotateComponent
  {
    public Transform Target;
    public Quaternion Rotation;
    public float Speed;
  }
}