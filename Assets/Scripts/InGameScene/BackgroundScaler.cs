using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    private float distance = 12f;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
        BackgroundScale();
    }

    private void BackgroundScale()
    {
        float screenHeight = 2f * distance * Mathf.Tan(mainCamera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        float screenWidth = screenHeight * mainCamera.aspect;

        transform.localScale = new Vector3(screenWidth, screenHeight, 1f);
    }
}
