using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private AudioClip Explosion; 

    private AudioSource AudioSoruce;
    private SpriteRenderer Sprite;
    private BoxCollider2D Collider;
    private Animator Animator;
    private float speed;
    private Vector3 direction;
    private bool isSet;

    public void Setup(Vector3 position, float speed, Vector3 direction)
    {
        transform.position = position;
        this.speed = speed;
        this.direction = direction;
        isSet = true; 
    }

    private void Start()
    {
        AudioSoruce = GetComponent<AudioSource>();
        Sprite = GetComponent<SpriteRenderer>();
        Collider = GetComponent<BoxCollider2D>();
        Animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (isSet)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Top Collider"))
        {
            Destroy(gameObject);
        }

        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Killer"))
        {
            Sprite.enabled = false;
            Collider.enabled = false;
            AudioSoruce.PlayOneShot(Explosion);


            Destroy(gameObject, 0.13f);
        }
    }


}
