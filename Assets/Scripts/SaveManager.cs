using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveManager : Singleton<SaveManager>
{
    public int MaxPoints;
    
    private GamePlayManager Manager;


    private void Start()
    {
        Manager = FindObjectOfType<GamePlayManager>();
        LoadSettings();
    }

    public void SaveSettings()
    {
        if (Manager.Points > MaxPoints)
        {
            PlayerPrefs.SetInt("MaxPoints", Manager.Points);
        }
    }

    public void LoadSettings()
    {
        MaxPoints = PlayerPrefs.GetInt("MaxPoints", MaxPoints);
    }
        


}
