using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerWave : MonoBehaviour, IHittable
{
    [SerializeField] private float MovementSpeed;

    private float StartPositionX;
    private float StartPositionY;
    private AudioSource AudioSource;

    private void Start()
    {
        StartPositionX = Random.Range(-3.2f, 3.2f);
        StartPositionY = Random.Range(11.0f, 13.0f);
        transform.position = new Vector3(StartPositionX, StartPositionY, 0f);

        AudioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        Movement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Bottom Collider"))
        {
            Destroy(gameObject);
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(gameObject);
        }

    }

    private void Movement()
    {
        transform.position += Vector3.down * MovementSpeed * Time.deltaTime;
    }

    public void OnHit()
    {
        Destroy(gameObject);
    }
}
