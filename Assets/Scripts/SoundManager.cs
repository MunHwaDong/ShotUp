using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{
    private enum MuteSprite
    {
        MUTE = 0,
        NOT_MUTE = 1
    }

    [SerializeField]
    private Sprite[] sprites;

    public delegate void ToggleMuteSprite(Sprite sprite);
    public event ToggleMuteSprite toggleMuteSprite;

    public void ToggleMute()
    {
        AudioSource bgm = GetComponent<AudioSource>();

        if (bgm.mute)
        {
            toggleMuteSprite?.Invoke(sprites[(int)MuteSprite.NOT_MUTE]);
        }
        else
        {
            toggleMuteSprite?.Invoke(sprites[(int)MuteSprite.MUTE]);
        }

        bgm.mute = !bgm.mute;
    }
}
