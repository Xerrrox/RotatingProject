using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _player;

    private Vector3 _offset;

    public void SetPlayer(Player player)
    {
        _player = player.GamePlayer.transform;
        transform.position = new Vector3(_player.position.x + player.GamePlayer.Height, _player.position.y + player.GamePlayer.Height, _player.position.z + player.GamePlayer.Height);
        transform.LookAt(_player);
       
        _offset = new Vector3(player.PlayerHeight, player.PlayerHeight * 1.5f, player.PlayerHeight);
    }

    private void Update()
    {
        if (_player != null)
            transform.position = _player.position + _offset;
    }
}
