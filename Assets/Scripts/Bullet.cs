using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private AudioClip Explosion; 

    private AudioSource m_AudioSoruce;
    private SpriteRenderer m_Sprite;
    private BoxCollider2D m_Collider;
    private Animator m_Animator;
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
        m_AudioSoruce = GetComponent<AudioSource>();
        m_Sprite = GetComponent<SpriteRenderer>();
        m_Collider = GetComponent<BoxCollider2D>();
        m_Animator = GetComponentInChildren<Animator>();
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
            //m_Animator.enabled = true;
            //m_Animator.Play(0);
            Destroy(gameObject);
        }

        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Killer"))
        {
            m_Sprite.enabled = false;
            m_Collider.enabled = false;
            m_AudioSoruce.PlayOneShot(Explosion);


            Destroy(gameObject, 0.13f);
        }
    }


}
