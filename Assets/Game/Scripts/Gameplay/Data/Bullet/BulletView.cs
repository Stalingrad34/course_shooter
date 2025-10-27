using UnityEngine;

namespace Game.Scripts.Gameplay.Data.Bullet
{
  public class BulletView : MonoBehaviour
  {
    public void Setup(BulletData data)
    {
      var setupComponents = gameObject.GetComponents<IBulletSetup>();
      foreach (var setupComponent in setupComponents)
      {
        setupComponent.Setup(data);
      }
    }
  }
}