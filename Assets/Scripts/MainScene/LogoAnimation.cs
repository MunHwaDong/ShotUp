using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LogoAnimation : MonoBehaviour
{
    public RectTransform Logo;
    public float amplitude = 30.0f;           // 진폭 (움직이는 최대 거리)
    public float frequency = 30.0f;            // 주파수 (움직이는 속도)

    private Vector2 originalPosition;         // Image의 원래 위치

    private void Awake()
    {
        if (Logo == null)
        {
            Logo = GetComponent<RectTransform>();
        }

        originalPosition = Logo.anchoredPosition;
    }

    private void OnEnable()
    {
        StartCoroutine(FloatAnimation());
    }

    private void OnDisable()
    {
        Logo.anchoredPosition = originalPosition;
    }

    private IEnumerator FloatAnimation()
    {
        while (true)
        {
            // Mathf.Sin을 이용하여 위아래로 둥실둥실 움직이게 만듦
            float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
            Logo.anchoredPosition = new Vector2(originalPosition.x, originalPosition.y - yOffset);

            yield return null;
        }
    }
}
