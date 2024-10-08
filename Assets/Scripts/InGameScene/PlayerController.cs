using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private ParticleSystem collisionParticle;

    private float rot = 0;
    private float pos = 0;

    private SpriteRenderer spriteRenderer;

    private AudioSource audioSource;

    private float dir = -1;

    private Vector3 playerInitPos;
    private Vector3 screenBound;
    private float spriteWidth;

    private Coroutine coroutine = null;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        spriteRenderer.sprite = GameManager.playerData.playerSprite;

        playerInitPos = gameObject.transform.position;
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        spriteWidth = spriteRenderer.bounds.extents.x;
    }

    private void OnEnable()
    {
        EventBus.Subscribe(EventType.START, StartIdleAnimation);
        EventBus.Subscribe(EventType.IDLE, StartIdleAnimation);
        EventBus.Subscribe(EventType.FOWARD, Foward);
        EventBus.Subscribe(EventType.CRUSH, PlayCollisionEffect);
        EventBus.Subscribe(EventType.RESTART, ResetPlayer);
    }

    public void StartIdleAnimation()
    {
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(IdleAnimation());
    }

    private void PlayCollisionEffect()
    {
        gameObject.SetActive(false);
        collisionParticle.transform.position = gameObject.transform.position;

        collisionParticle.gameObject.SetActive(true);
        collisionParticle.Play();
    }

    private IEnumerator IdleAnimation()
    {
        //언제든지, 플레이어 인풋이 들어오면 실행이 멈춰야하므로 Update()대신 코루틴으로 구현함
        while(true)
        {
            rot += Time.deltaTime * rotateSpeed * dir * -1;
            pos += Time.deltaTime * moveSpeed * dir;
            Clamp(pos);

            transform.rotation = Quaternion.Euler(0, 0, rot);
            transform.position = new Vector3(pos, transform.position.y, transform.position.z);
            yield return null;
        }
    }

    private void ResetPlayer()
    {
        gameObject.transform.position = playerInitPos;
        collisionParticle.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    private void Foward()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);
        audioSource.Play();
    }

    private void Clamp(float pos)
    {
        if (pos >= -screenBound.x - spriteWidth) dir = -1;
        if (pos <= screenBound.x + spriteWidth) dir = 1;
    }

    public void SetPlayerSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
}
