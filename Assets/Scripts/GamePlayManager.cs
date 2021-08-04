using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : Singleton<GamePlayManager>
{
    public int lifes;
    public int m_points = 0;

    [Header("Lifes")]
    public GameObject FirstLife;
    public GameObject SecondLife;
    public GameObject ThirdLife;

    [Header("Prefabs")]
    public GameObject Bonus;
    public GameObject KillerWave;
    public GameObject BlueBallWave;

    private HUDController m_HUD;
    private Head m_Head;
    private Bonus m_Bonus;
    private int RandomKiller;

    

    public int Points
    {
        get { return m_points; }
        set
        {
            m_points = value;
            m_HUD.UpdatePoints(m_points);
        }
    }
  
    private void Start()
    {
        m_HUD = FindObjectOfType<HUDController>();
        m_Head = FindObjectOfType<Head>();
        m_Bonus = FindObjectOfType<Bonus>();

        Points = 0;
        lifes = 3;

        StartCoroutine(BonusInstantate());
        StartCoroutine(DeathWave());
    }

    private void Update()
    {
        Life();
    }

    private void Life()
    {
        if (lifes != 3)
        {
            if (lifes <= 2)
            {
                Destroy(ThirdLife);

                if (lifes <= 1)
                {
                    Destroy(SecondLife);

                    if (lifes <= 0)
                    {
                        Destroy(FirstLife);
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    }
                }
            }
        }
    }

    IEnumerator DeathWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(15, 30));
            for (RandomKiller = Random.Range(12, 14); RandomKiller >= 0; --RandomKiller)
            {
                GameObject.Instantiate(KillerWave, Vector3.zero, Quaternion.identity);    
            }
        }
    }

    IEnumerator BonusInstantate()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(15,20));
            GameObject.Instantiate(Bonus, Vector3.zero, Quaternion.identity);
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
