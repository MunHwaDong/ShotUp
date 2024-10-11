using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Wall : MonoBehaviour
{
    public IObjectPool<Wall> pool { get; set; }

    private float fowardSpeed = 15f;
    private float fowardingTime = 0.5f;

    private Coroutine coroutine = null;
    private float screenUnderBound = 0f;

    private void Awake()
    {
        screenUnderBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)).y;
    }

    private void OnEnable()
    {
        EventBus.Subscribe(EventType.FOWARD, FowardWall);
        EventBus.Subscribe(EventType.RESTART, ResetWall);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(EventType.FOWARD, FowardWall);
        EventBus.Unsubscribe(EventType.RESTART, ResetWall);
    }

    private void FowardWall()
    {
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = StartCoroutine(GoFowardWall());
    }

    private IEnumerator GoFowardWall()
    {
        float percent = 0f;
        Vector3 objPos = transform.position;

        while (percent < fowardingTime)
        {
            transform.position += new Vector3(objPos.x, -Time.deltaTime * fowardSpeed, objPos.z);
            percent += Time.deltaTime;

            yield return null;
        }

        if (transform.position.y < screenUnderBound)
        {
            StopCoroutine(coroutine);
            ReturnToPool();
        }
    }

    private void ResetWall()
    {
        coroutine = null;

        ReturnToPool();
    }

    private void ReturnToPool()
    {
        pool.Release(this);
    }
}
