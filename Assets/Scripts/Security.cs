using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Security : MonoBehaviour
{
    private Head Head;
    private Transform Transform;

    private void Start()
    {
        Head = FindObjectOfType<Head>();
        Transform = Head.GetComponent<Transform>();

        transform.position = Transform.position;
        transform.localScale = new Vector3(0.21f, 0.21f, 1f);
    }

    private void OnEnable()
    {
        Invoke("DeactivateAfterSeconds", 8f);
    }

    private void Update()
    {
        transform.position = new Vector3(Transform.position.x, Transform.position.y, Transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IHittable hittable = collision.collider.GetComponent<IHittable>();

        if (hittable != null)
        {
            hittable.OnHit();
            gameObject.SetActive(false);
        }
    }

    private void DeactivateAfterSeconds()
    {
        gameObject.SetActive(false);
    }
}
