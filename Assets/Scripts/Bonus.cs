using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{

    public GameObject BlueBallWave;
    public GameObject Security;
    public int isCatched;

    private int RandomBall;
    private float RandomBonus;
    private float StartpositionX;
    private float StartpositionY;
    private Head m_Head;

    private void Start()
    {
        m_Head = FindObjectOfType<Head>();

        StartpositionX = Random.Range(-3.7f, 3.7f);
        StartpositionY = Random.Range(-4f, 4f);
        RandomBonus = Random.Range(1, 5);

        Destroy(gameObject, 8f);

        transform.position = new Vector3(StartpositionX, StartpositionY, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Head"))
        {
            m_Head.HeadMovementSpeed = 4.0f;

            GamePlayManager.Instance.Bullets += 10;

            if (RandomBonus <= 1)
            {
                for (RandomBall = Random.Range(5, 7); RandomBall >= 0; --RandomBall)
                {
                    GameObject.Instantiate(BlueBallWave, Vector3.zero, Quaternion.identity);
                }
            }

            if (RandomBonus >= 2)
            {
                GameObject.Instantiate(Security, Vector3.zero, Quaternion.identity);
            }
            gameObject.SetActive(false);
        }
    }
}
