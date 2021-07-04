using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
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
    }


}
