using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    [SerializeField] private TMPro.TextMeshProUGUI Score;
    [SerializeField] private TMPro.TextMeshProUGUI BestScore;

    private GamePlayManager Manager;
    private SaveManager Save;

    private void Start()
    {
        Manager = FindObjectOfType<GamePlayManager>();
        Save = FindObjectOfType<SaveManager>();
    }

    private void Update()
    {
        Score.text = "SCORE: " + Manager.Points;
        BestScore.text = "BEST SCORE: " + Save.MaxPoints;
    }
}
