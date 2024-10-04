using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMuteBehaviour : MonoBehaviour
{
    private SoundManager soundManager;

    private Image soundSpriteRenderer;

    private void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        soundSpriteRenderer = GetComponent<Image>();

        soundManager.toggleMuteSprite += ToggleMuteSprite;
        gameObject.GetComponent<Button>().onClick.AddListener(ToggleMute);
    }

    private void ToggleMute()
    {
        soundManager.ToggleMute();
    }

    private void ToggleMuteSprite(Sprite sprite)
    {
        soundSpriteRenderer.sprite = sprite;
    }
}
