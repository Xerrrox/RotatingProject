using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _playerHeight;

    [SerializeField]
    private PlayerSegment prefab;

    [SerializeField]
    private PlayerVisualizator _playerVisualizator;

    public int PlayerHeight { get => _playerHeight; }

    public Vector2 StartPoint { get; private set; }

    public PlayerSegment GamePlayer { get; private set; }

    private HashSet<Vector3> _segments = new HashSet<Vector3>();

    public HashSet<Vector3> Segments { get => _segments; }

    public void Initialize(Vector2 startPoint)
    {
        StartPoint = new Vector2(startPoint.x - 2, startPoint.y + prefab.Height / 2); ;
        var _buildingDirections = new Vector3[]
        {
            new Vector3(0, prefab.Height, 0),
            new Vector3(0, -prefab.Height, 0),
            new Vector3(prefab.Height, 0, 0),
            new Vector3(-prefab.Height, 0, 0),
            new Vector3(0, 0, prefab.Height),
            new Vector3(0, 0, -prefab.Height),
        };

        //add a pillar
        for (int i = 0; i < PlayerHeight; i++)
        {
            _segments.Add(new Vector3(0, 0 + (prefab.Height * i), z: 0));
        }

        //add some branches
        for (int i = 0; i < PlayerHeight * 5; i++)
        {
            var startBuildingSegment = _segments
                                        .Skip(Random.Range(0, _segments.Count))
                                        .First();

            var buildDirection = _buildingDirections
                                 .Skip(Random.Range(0, _buildingDirections.Length))
                                 .First();
            var newSegment = startBuildingSegment + buildDirection;

            if (newSegment.y > 0 && newSegment.y < _playerHeight && newSegment.x < _playerHeight / 2 + prefab.Height && newSegment.z < _playerHeight / 2 + prefab.Height)
                _segments.Add(newSegment);
            else
                i--;
        }

        GamePlayer = _playerVisualizator.BuildPlayer(_segments, prefab);
        GamePlayer.transform.SetParent(transform);
        GamePlayer.gameObject.AddComponent<RotateControll>();
        transform.localPosition = StartPoint;
    }
}
