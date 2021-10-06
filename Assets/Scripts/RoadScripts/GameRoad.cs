using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoad : MonoBehaviour
{
    [SerializeField]
    private Transform _ground;

    [SerializeField]
    private Transform _finishLine;

    public Vector2 Size { get; private set; }

    public void Initialize(Player player)
    {
        var roadWidth = player.PlayerHeight + 3;
       // roadWidth = roadWidth > 5 ? (roadWidth < 20 ? roadWidth : 20) : 5;
        Size = new Vector2(player.PlayerHeight * 50, roadWidth);
        _finishLine.localScale = new Vector3(player.PlayerHeight, Size.y, z: 1);
        _finishLine.transform.localPosition = new Vector3(-(Size.x / 2f + player.PlayerHeight / 2f), 0, 0);
        _ground.localScale = new Vector3(Size.x, Size.y, z: 1);
    }
}
