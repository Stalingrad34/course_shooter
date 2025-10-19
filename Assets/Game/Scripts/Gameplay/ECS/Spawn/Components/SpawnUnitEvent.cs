using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Spawn.Components
{
  public struct SpawnUnitEvent
  {
    public string Id;
    public Vector3 Position;
    public bool IsPlayer;
  }
}