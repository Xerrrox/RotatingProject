using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSegment : MonoBehaviour
{
    public UnityEvent CollisionEvent;

    public float Height
    {
        get
        {           
            return transform.localScale.y;
        }
    }

    [ContextMenu("Initialization")]
    private void Initializing()
    {
        if (transform.localScale.x != 1 || transform.localScale.y != 1 || transform.localScale.z != 1)
            transform.localScale = new Vector3(1, 1, 1);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "wall")
        {
            CollisionEvent.Invoke();
            Destroy(other.gameObject, 1f);
        }
    }

}
