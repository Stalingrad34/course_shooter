using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Crouch.Components
{
  public struct CrouchComponent
  {
    public Transform CrouchRoot;
    public float CrouchPosY;
    public bool IsCrouch;
  }
}