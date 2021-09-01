using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBallControler : MonoBehaviour
{
    [SerializeField] AudioClip Good;
    [SerializeField] private float MovementSpeed;

    private float StartPositionX;
    private float StartPositionY;
    private AudioSource m_AudioSource;
    
    private void Start()
    {
        StartPositionX = Random.Range(-3.2f, 3.2f);
        StartPositionY = Random.Range(6.0f, 8.0f);
        transform.position = new Vector3(StartPositionX, StartPositionY, 0f);

        m_AudioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        Movement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Head"))
        {
            GamePlayManager.Instance.Points += 1;
            GamePlayManager.Instance.Bullets += 1;
            m_AudioSource.PlayOneShot(Good);
            StartPosition();
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Bottom Collider"))
        {
            StartPosition();
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
