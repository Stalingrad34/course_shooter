using System.Collections.Generic;
using Colyseus.Schema;

namespace Game.Scripts.Gameplay.ECS.PlayerChange.Components
{
  public struct PlayerChangeEvent
  {
    public string Id;
    public List<DataChange> Changes;
    public float AverageInterval;
  }
}