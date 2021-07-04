using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float MaxPosition = 3.0f;

    public Vector3 HeadPosition;
    public Bullet bulletfab;
    public Transform bulletOrigin;
    public float bulletSpeed = 5f;
    

    private Killer killer;
   

    private void Start()
    {
        killer = FindObjectOfType<Killer>();
        
    }

    void Update()
    {
        Movement();
        Shoot();
        if (killer.hitTheHead == true)
        {
            Destroy(gameObject); 
        }
       
        
    }

    private void Movement()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        if ((direction > 0 && transform.position.x < MaxPosition) || (direction < 0 && transform.position.x > -MaxPosition))
            
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
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

}
