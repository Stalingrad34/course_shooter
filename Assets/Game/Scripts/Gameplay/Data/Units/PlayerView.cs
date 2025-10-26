using System;
using Game.Scripts.Gameplay.ECS.Common;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Game.Scripts.Gameplay.Data.Units
{
  public class PlayerView : UnitView
  {
    [SerializeField] private ConvertToEntity entityConverter;
    [SerializeField] private Transform cameraPoint;

    public void SetCameraPoint(Camera mainCamera)
    {
      mainCamera.transform.SetParent(cameraPoint);
      mainCamera.transform.localRotation = Quaternion.identity;
      mainCamera.transform.localPosition = Vector3.zero;
    }

    /*private void OnCollisionStay(Collision collision)
    {
      foreach (var contact in collision.contacts)
      {
        if (contact.normal.y > 0.45f)
        {
          var entity = entityConverter.TryGetEntity();
          if (entity.HasValue)
          {
            entity.Value.Get<OnCollisionStayEvent>().Collision = collision;
          }
        }
      }
    }

    private void OnCollisionExit(Collision collision)
    {
      var entity = entityConverter.TryGetEntity();
      if (entity.HasValue)
      {
        entity.Value.Get<OnCollisionExitEvent>().Collision = collision;
      }
    }*/
  }
}