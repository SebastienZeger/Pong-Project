using UnityEngine;
using UnityEngine.Events;

public class testScore : MonoBehaviour
{
    public UnityEvent scoreTrigger;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            scoreTrigger.Invoke();

        }
        
    }
}
