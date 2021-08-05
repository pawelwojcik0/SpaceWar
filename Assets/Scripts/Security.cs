using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Security : MonoBehaviour
{
    private Head m_Head;
    private Transform m_Transform;

    private void Start()
    {
        m_Head = FindObjectOfType<Head>();
        m_Transform = m_Head.GetComponent<Transform>();

        transform.position = m_Transform.position;
        transform.localScale = new Vector3(0.21f, 0.21f, 1f);
        Destroy(gameObject, 8f);
    }

    private void Update()
    {
        transform.position = new Vector3(m_Transform.position.x, m_Transform.position.y, m_Transform.position.z);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IHittable hittable = collision.collider.GetComponent<IHittable>();

        if (hittable != null)
        {
            hittable.OnHit();
            Destroy(gameObject);
        }
            
     
    }
}
