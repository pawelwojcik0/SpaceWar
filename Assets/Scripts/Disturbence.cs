using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disturbence : MonoBehaviour
{
    private Head Head;
    private float StartpositionX;
    private float StartpositionY;

    private void Start()
    {
        Head = FindObjectOfType<Head>();

        StartpositionX = Random.Range(-3.7f, 3.7f);
        StartpositionY = Random.Range(-4f, 4f);

        transform.position = new Vector3(StartpositionX, StartpositionY, 0f);
        Destroy(gameObject, 10);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Head"))
        {
            Head.HeadMovementSpeed = Random.Range(1.8f, 3.5f);
            Destroy(gameObject);
        }
    }



}
