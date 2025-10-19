using UnityEngine;

namespace Game.Scripts.Gameplay.Data.Units
{
  public abstract class UnitView : MonoBehaviour
  {
    public void Setup(UnitData data)
    {
      var setupComponents = gameObject.GetComponents<IUnitSetup>();
      foreach (var setupComponent in setupComponents)
      {
        setupComponent.Setup(data);
      }
    }
  }
}