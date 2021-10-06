using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class Wall : ScriptableObject
{
    [SerializeField]
    private WallVisualizator _wallVisualizator;

    [SerializeField]
    private WallSegment prefab;

    private HashSet<HashSet<Vector3>> _wallVariants = new HashSet<HashSet<Vector3>>();

    private Player _player;
    private GameRoad _road;

    private int _numWals = 6;

    public void Initialize(Player player, GameRoad road)
    {
        _player = player;
        _road = road;
        SetWallVariants();
        BuildWallVariants();         
    }

    private void BuildWallVariants()
    {
        for (float i = -_numWals / 2; i < _numWals / 2; i++)
        {
            HashSet<Vector3> wallPoint = new HashSet<Vector3>();
            var betweenDistance = _road.Size.x / _numWals - _player.PlayerHeight;
            var currentPosition = betweenDistance * i;

            var wallVariant = _wallVariants
                                .Skip(UnityEngine.Random.Range(0, _wallVariants.Count))
                                .First();

            foreach(var segment in wallVariant)
            {
                wallPoint.Add(new Vector3(segment.x + currentPosition, segment.y, segment.z));
            }
            _wallVisualizator.BuildWall(wallPoint, prefab);
        }

        //_wallVisualizator.BuildWalls(_wallVariants, prefab);
    }

    private void SetWallVariants()
    {
        _wallVariants = new HashSet<HashSet<Vector3>>();

        //culculate unique for xy axis and yz axis
        HashSet<Vector3> xy = new HashSet<Vector3>();
        HashSet<Vector3> yz = new HashSet<Vector3>();

        foreach (var segment in _player.Segments)
        {
            if (xy.Count > 0)
            {
                if (!xy.Where(i => i.x == segment.x && i.y == segment.y).Any())
                {
                    xy.Add(segment);
                }
            }
            else
            {
                xy.Add(segment);
            }
        }


        foreach (var segment in _player.Segments)
        {
            if (yz.Count > 0)
            {
                if (!yz.Where(i => i.y == segment.y && i.z == segment.z).Any())
                {
                    yz.Add(segment);
                }
            }
            else
            {
                yz.Add(segment);
            }
        }


        //Generate wall variants
        HashSet<Vector3> wall1 = new HashSet<Vector3>();
        HashSet<Vector3> wall2 = new HashSet<Vector3>();
        for (float x = - _player.PlayerHeight / 2 - prefab.Height; x < _player.PlayerHeight / 2 + prefab.Height; x++)
        {
            for (int y = 0; y < _player.PlayerHeight + prefab.Height; y++)
            {
                if (!xy.Where(i => i.x == x && i.y == y).Any())
                {
                    wall1.Add(new Vector3(0, y + _player.StartPoint.y, x));
                    wall2.Add(new Vector3(0, y + _player.StartPoint.y, -x));
                }
            }
        }
        _wallVariants.Add(wall1);
        _wallVariants.Add(wall2);

        HashSet<Vector3> wall3 = new HashSet<Vector3>();
        HashSet<Vector3> wall4 = new HashSet<Vector3>();

        for (float z = - _player.PlayerHeight / 2 - prefab.Height; z < _player.PlayerHeight / 2 + prefab.Height; z++)
        {
            for (int y = 0; y < _player.PlayerHeight + prefab.Height; y++)
            {
                if (!yz.Where(i => i.y == y && i.z == z).Any())
                {
                    wall3.Add(new Vector3(0, y + _player.StartPoint.y, z));
                    wall4.Add(new Vector3(0, y + _player.StartPoint.y, -z));
                }
            }
        }
        _wallVariants.Add(wall3);
        _wallVariants.Add(wall4);

    }
}
