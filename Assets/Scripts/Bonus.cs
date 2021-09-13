using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public GameObject BlueBallWave;
    public GameObject Security;

    private int RandomBall;
    private float RandomBonus;
    private float StartpositionX;
    private float StartpositionY;
    private Head Head;

    private void Start()
    {
        Head = FindObjectOfType<Head>();

        StartpositionX = Random.Range(-3.7f, 3.7f);
        StartpositionY = Random.Range(-4f, 4f);
        RandomBonus = Random.Range(1, 5);

        Invoke("DeactivateAfterSeconds", 8f);

        transform.position = new Vector3(StartpositionX, StartpositionY, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Head"))
        {
            Head.HeadMovementSpeed = 4.0f;

            GamePlayManager.Instance.Bullets += 7;

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
    private void DeactivateAfterSeconds()
    {
        gameObject.SetActive(false);
    }

}
