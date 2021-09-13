using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : Singleton<GamePlayManager>
{
    public int lifes;
    public int m_points = 0;
    public int m_bullets = 0;

    [Header("Lifes")]
    [SerializeField] private GameObject FirstLife;
    [SerializeField] private GameObject SecondLife;
    [SerializeField] private GameObject ThirdLife;

    [Header("Prefabs")]
    [SerializeField] private GameObject Bonus;
    [SerializeField] private GameObject KillerWave;
    [SerializeField] private GameObject BlueBallWave;
    [SerializeField] private GameObject Disturbence;
    [SerializeField] private GameObject m_GameOver;

    private HUDController HUD;
    private int RandomKiller;

    public int Bullets
    {
        get { return m_bullets; }
        set
        {
            m_bullets = value;
            HUD.UpdateBullet(m_bullets);
        }
    }

    public int Points
    {
        get { return m_points; }
        set
        {
            m_points = value;
            HUD.UpdatePoints(m_points);
        }
    }
  
    private void Start()
    {
        HUD = FindObjectOfType<HUDController>();

        Bullets = 10;
        Points = 0;
        lifes = 3;

        StartCoroutine(BonusInstantiate());
        StartCoroutine(DeathWave());
        StartCoroutine(DisturbenceInstantiate());

        m_GameOver.SetActive(false);

    }

    private void Update()
    {
        Life();
        Restart();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
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
                        GameOver();
                    }
                }
            }
        }
    }

    IEnumerator DeathWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(6, 8));
            for (RandomKiller = Random.Range(12, 14); RandomKiller >= 0; --RandomKiller)
            {
                GameObject.Instantiate(KillerWave, Vector3.zero, Quaternion.identity);    
            }
        }
    }

    IEnumerator BonusInstantiate()
    {
        while (true)
        {
           
            yield return new WaitForSeconds(Random.Range(8, 10));
            GameObject.Instantiate(Bonus, Vector3.zero, Quaternion.identity);
        }
    }

    IEnumerator DisturbenceInstantiate()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(9, 12));
            GameObject.Instantiate(Disturbence, Vector3.zero, Quaternion.identity);
        }
    }    
   
    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    public void GameOver()
    {
        SaveManager.Instance.SaveSettings();
        m_GameOver.gameObject.SetActive(true);
    }

    private void Restart()
    {
        if (m_GameOver.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
