using UnityEngine;

namespace Game.Scripts.Gameplay.Data.Units
{
  public class UnitAnimator : MonoBehaviour
  {
    private readonly int _grounded = Animator.StringToHash("Grounded");
    private readonly int _speed = Animator.StringToHash("Speed");
    
    [SerializeField] private Animator footAnimator;

    public void SetFlyAnimation(bool isFly)
    {
      footAnimator.SetBool(_grounded, isFly);
    }
    
    public void SetMoveAnimation(float speed)
    {
      footAnimator.SetFloat(_speed, speed);
    }
  }
}