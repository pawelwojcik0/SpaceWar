using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveManager : Singleton<SaveManager>
{
    public int MaxPoints;
    
    private GamePlayManager m_Manager;


    private void Start()
    {
        m_Manager = FindObjectOfType<GamePlayManager>();
        LoadSettings();
    }

    public void SaveSettings()
    {
        if (m_Manager.Points > MaxPoints)
        {
            PlayerPrefs.SetInt("MaxPoints", m_Manager.Points);
        }
    }

    public void LoadSettings()
    {
        MaxPoints = PlayerPrefs.GetInt("MaxPoints", MaxPoints);
    }
        


}
