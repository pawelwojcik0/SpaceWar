using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : Singleton<GamePlayManager>
{
    public int lifes;

    private HUDController m_HUD;
    private int m_points = 0;
    


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
        Points = 0;
        lifes = 3;
    }

    private void Update()
    {

        if (lifes != 3)
        {
            if (lifes <= 2)
            {
                Destroy(GameObject.Find("ThirdLife"));

                if (lifes == 1)
                {
                    Destroy(GameObject.Find("SecondLife"));

                    if (lifes <=0)
                    {

                    }
                }
            }
        }
    }





}
