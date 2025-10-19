using System.Collections.Generic;
using Colyseus.Schema;
using Game.Scripts.Gameplay.ECS.Common;
using Leopotam.Ecs;
using Voody.UniLeo;

namespace Game.Scripts.Multiplayer
{
  public class PlayerChangesHandler
  {
    private readonly string _playerId;

    public PlayerChangesHandler(string playerId)
    {
      _playerId = playerId;
    }

    public void OnPlayerChanged(List<DataChange> changes)
    {
      ref var changeEvent = ref WorldHandler.GetWorld().NewEntity().Get<PlayerChangeEvent>();
      changeEvent.Id = _playerId;
      changeEvent.Changes = changes;
    }
  }
}