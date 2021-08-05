using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Head : MonoBehaviour
{
    [SerializeField] public float HeadMovementSpeed;
    [SerializeField] private float MaxPositionX = 3.0f;
    [SerializeField] private float MaxPositionY = 4.6f;

    public Vector3 HeadPosition;
    public Bullet bulletfab;
    public Transform bulletOrigin;
    public float bulletSpeed = 5f;

    private GamePlayManager m_Manager;
    private AudioSource m_AudioSoruce;

    private void Start()
    {
        m_Manager = FindObjectOfType<GamePlayManager>();

        m_AudioSoruce = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Movement();
        Shoot();
    }

    private void Movement()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        if ((directionX > 0 && transform.position.x < MaxPositionX) || (directionX < 0 && transform.position.x > -MaxPositionX))

        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * HeadMovementSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * HeadMovementSpeed * Time.deltaTime;
            }
        }

        float directionY = Input.GetAxisRaw("Vertical");
        if ((directionY > 0 && transform.position.y < MaxPositionY) || (directionY < 0 && transform.position.y > -MaxPositionY))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += Vector3.up * HeadMovementSpeed * Time.deltaTime;
            }    

            if(Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += Vector3.down * HeadMovementSpeed * Time.deltaTime;
            }
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && m_Manager.Bullets > 0)
        {
            Bullet bullet = Instantiate(bulletfab);
            bullet.Setup(bulletOrigin.position, bulletSpeed, Vector3.up);
            GamePlayManager.Instance.Bullets -= 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Killer"))
        {
            Destroy(gameObject);
            m_Manager.GameOver();
        }  
    }
}
