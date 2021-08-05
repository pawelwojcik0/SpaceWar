using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBallControler : MonoBehaviour
{

    [SerializeField] AudioClip Bad;
    [SerializeField] private float MovementSpeed;

    private float StartPositionX;
    private float StartPositionY;
    private AudioSource m_AudioSource;
    private GamePlayManager m_GamePlayManager;
    

    private void Start()
    {
        StartPositionX = Random.Range(-3.2f, 3.2f);
        StartPositionY = Random.Range(7.0f, 10.0f);
        transform.position = new Vector3(StartPositionX, StartPositionY, 0f);

        m_AudioSource = GetComponent<AudioSource>();
        m_GamePlayManager = FindObjectOfType<GamePlayManager>();
    }
    void Update()
    {
        Movement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Head"))
        {
            m_AudioSource.PlayOneShot(Bad);
            StartPosition();
            m_GamePlayManager.lifes -= 1;
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Bottom Collider"))
        {
            StartPosition();
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Security"))
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
