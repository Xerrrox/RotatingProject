using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSegment : MonoBehaviour
{
    [SerializeField]
    private PlayerSegment _playerSegment;
    public float Height
    {
        get
        {           
            return this.transform.localScale.y;
        }
    }

    [ContextMenu("Initialization")]
    private void Initializing()
    {
        if (transform.localScale.x != _playerSegment.transform.localScale.x || transform.localScale.y != _playerSegment.transform.localScale.y || transform.localScale.z != _playerSegment.transform.localScale.z)
            transform.localScale = new Vector3(_playerSegment.transform.localScale.y, _playerSegment.transform.localScale.y, _playerSegment.transform.localScale.y);
    }
}
