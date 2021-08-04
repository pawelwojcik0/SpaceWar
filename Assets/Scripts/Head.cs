using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Head : MonoBehaviour
{
    [SerializeField] private float MovementSpeed;
    [SerializeField] private float MaxPositionX = 3.0f;
    [SerializeField] private float MaxPositionY = 4.6f;

    public Vector3 HeadPosition;
    public Bullet bulletfab;
    public Transform bulletOrigin;
    public float bulletSpeed = 5f;
    
    private AudioSource m_AudioSoruce;

    private void Start()
    {
        m_AudioSoruce = GetComponent<AudioSource>();
    }

    void Update()
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
                transform.position += Vector3.right * MovementSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * MovementSpeed * Time.deltaTime;
            }
        }

        float directionY = Input.GetAxisRaw("Vertical");
        if ((directionY > 0 && transform.position.y < MaxPositionY) || (directionY < 0 && transform.position.y > -MaxPositionY))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += Vector3.up * MovementSpeed * Time.deltaTime;
            }    

            if(Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += Vector3.down * MovementSpeed * Time.deltaTime;
            }
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bullet bullet = Instantiate(bulletfab);
            bullet.Setup(bulletOrigin.position, bulletSpeed, Vector3.up);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Killer"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
            
    }

}
