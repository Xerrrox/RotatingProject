using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class PlayerVisualizator : GameObjectsFactory
{
    public PlayerSegment BuildPlayer(HashSet<Vector3> segments, PlayerSegment prefab)
    {
        var parentSegment = CreateGameObjectInstance(prefab);
        parentSegment.transform.position = segments.First();

        foreach (var segmentPosition in segments)
        {          
            if (segmentPosition != segments.First())
            {
                var playerSegment = CreateGameObjectInstance(prefab);
                playerSegment.transform.position = segmentPosition;
                playerSegment.transform.SetParent(parentSegment.transform);
            }
        }

        return parentSegment;
    }
}
