using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    [SerializeField] private float MovementSpeed;
    
    private float StartPositionX = 0.0f;
    private float StartPositionY = 6.0f;
    private AudioSource m_AudioSource;
    

    private void Start()
    {
        StartPositionX = Random.Range(-3.2f, 3.2f);
        StartPositionY = Random.Range(11.0f, 13.0f);
        transform.position = new Vector3(StartPositionX, StartPositionY, 0f);

        m_AudioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        Movement();
    }
     
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Bottom Collider"))
        {
            StartPosition();
        }
       
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Bullet"))
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
