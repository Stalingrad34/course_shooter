using Game.Scripts.Gameplay.ECS.Common;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Game.Scripts.Gameplay.Data.Bullet
{
  public class BulletView : MonoBehaviour
  {
    [SerializeField] private ConvertToEntity entityConverter;
    
    public void Setup(BulletData data)
    {
      var setupComponents = gameObject.GetComponents<IBulletSetup>();
      foreach (var setupComponent in setupComponents)
      {
        setupComponent.Setup(data);
      }
    }

    private void OnCollisionEnter(Collision collision)
    {
      var entity = entityConverter.TryGetEntity();
      if (entity.HasValue)
      {
        ref var collisionEvent = ref entity.Value.Get<OnCollisionEnterEvent>();
        collisionEvent.Collision = collision;
        collisionEvent.GameObject = collision.gameObject;
      }
    }
  }
}