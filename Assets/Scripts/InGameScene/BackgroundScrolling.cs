using System.Collections;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    private float scrollSpeed = 1f;
    private Material myMaterial;
    private Coroutine coroutine;
    private float scrollTime = 0.5f;
    private bool isCrushed = false;

    private void Awake()
    {
        myMaterial = GetComponent<Renderer>().material;
        EventBus.Subscribe(EventType.FOWARD, GoFoward);
        EventBus.Subscribe(EventType.CRUSH, CrushedCheck);
        EventBus.Subscribe(EventType.RESTART, ResetCrushInfo);
    }

    private void ResetCrushInfo()
    {
        isCrushed = false;
    }

    private void GoFoward()
    {
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = StartCoroutine(Scroll());
    }

    private void CrushedCheck()
    {
        isCrushed = true;
    }

    private IEnumerator Scroll()
    {
        float percent = 0f;

        while(percent < scrollTime)
        {
            float newOffsetY = myMaterial.mainTextureOffset.y + Time.deltaTime * scrollSpeed;
            percent += Time.deltaTime;
            Vector2 newOffSet = new Vector2(0, newOffsetY);
            myMaterial.mainTextureOffset = newOffSet;

            yield return null;
        }

        if(!isCrushed)
        {
            EventBus.Publish(EventType.IDLE);
        }
    }
}