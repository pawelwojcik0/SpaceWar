using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBallWave : MonoBehaviour
{

    [SerializeField] AudioClip Good;
    [SerializeField] private float MovementSpeed;

    private float StartPositionX = 0.0f;
    private float StartPositionY = 6.0f;
    private AudioSource m_AudioSource;
    private SpriteRenderer m_Sprite;
    private CircleCollider2D m_Collider;

    private void Start()
    {
        StartPositionX = Random.Range(-3.2f, 3.2f);
        StartPositionY = Random.Range(6.0f, 8.0f);
        transform.position = new Vector3(StartPositionX, StartPositionY, 0f);

        m_AudioSource = GetComponent<AudioSource>();
        m_Collider = GetComponent<CircleCollider2D>();
        m_Sprite = GetComponent<SpriteRenderer>();

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
            m_AudioSource.PlayOneShot(Good);
            m_Sprite.enabled = false;
            m_Collider.enabled = false;
            Destroy(gameObject, 0.5f);
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Bottom Collider"))
        {
            Destroy(gameObject);
        }
    }

    private void StartPosition()
    {
        StartPositionX = Random.Range(-3.2f, 3.2f);
        transform.position = new Vector3(StartPositionX, StartPositionY, 0f);
    }

    private void Movement()
    {
        transform.position += Vector3.down * MovementSpeed * Time.deltaTime;
    }
}