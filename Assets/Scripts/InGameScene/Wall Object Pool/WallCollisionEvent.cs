using UnityEngine;

public class WallCollisionEvent : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Crushed");
            EventBus.Publish(EventType.CRUSH);
        }
    }
}
