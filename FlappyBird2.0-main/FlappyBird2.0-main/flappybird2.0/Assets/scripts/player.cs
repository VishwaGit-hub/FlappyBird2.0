using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Vector3 direction;
    public float gravity = -9.6f;
    public float strength = 5f;


    private SpriteRenderer spriterenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    public AudioClip jumpSound;
    public AudioClip gameoverSound;
    public AudioClip scoreSound;

    private void Awake()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite),0.15f,0.15f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
            SoundManager.instance.PlaySound(jumpSound);

        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
                SoundManager.instance.PlaySound(jumpSound);
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        spriteIndex++;
        if(spriteIndex>= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriterenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Obstacle")
        {
            FindObjectOfType<gamemanager>().GameOver();
            SoundManager.instance.PlaySound(gameoverSound);

        }
        else if(other.gameObject.tag=="Scoring")
        {
            FindObjectOfType<gamemanager>().IncreaseScore();
            SoundManager.instance.PlaySound(scoreSound);
        }
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;

    }
}
