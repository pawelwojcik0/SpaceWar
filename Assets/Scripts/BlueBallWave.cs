using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBallWave : MonoBehaviour
{

    [SerializeField] AudioClip Good;
    [SerializeField] private float MovementSpeed;

    private float StartPositionX;
    private float StartPositionY;
    private AudioSource AudioSource;
    private SpriteRenderer Sprite;
    private CircleCollider2D Collider;

    private void Start()
    {
        StartPositionX = Random.Range(-3.2f, 3.2f);
        StartPositionY = Random.Range(6.0f, 8.0f);
        transform.position = new Vector3(StartPositionX, StartPositionY, 0f);

        AudioSource = GetComponent<AudioSource>();
        Collider = GetComponent<CircleCollider2D>();
        Sprite = GetComponent<SpriteRenderer>();

    }
    private void Update()
    {
        Movement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Head"))
        {
            GamePlayManager.Instance.Points += 1;
            GamePlayManager.Instance.Bullets += 1;
            AudioSource.PlayOneShot(Good);
            Sprite.enabled = false;
            Collider.enabled = false;
            Destroy(gameObject, 0.5f);
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Bottom Collider"))
        {
            Destroy(gameObject);
        }
    }

    private void Movement()
    {
        transform.position += Vector3.down * MovementSpeed * Time.deltaTime;
    }
}
