using UnityEngine;
using UnityEngine.UI;

public class RestartBehaviour : MonoBehaviour
{

    private void Awake()
    {
        gameObject.AddComponent<Button>().onClick.AddListener(Restart);
    }

    private void Restart()
    {
        EventBus.Publish(EventType.RESTART);
        EventBus.Publish(EventType.START);
    }
}
