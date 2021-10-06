using UnityEngine;
using UnityEngine.Events;

public class FinishTrigger : MonoBehaviour
{   
    public UnityEvent FinishReached;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FinishReached.Invoke();
        }
    }
}
