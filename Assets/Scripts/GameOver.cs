using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    [SerializeField] private TMPro.TextMeshProUGUI Score;
    [SerializeField] private TMPro.TextMeshProUGUI BestScore;

    private GamePlayManager m_Manager;
    private SaveManager m_Save;

    private void Start()
    {
        m_Manager = FindObjectOfType<GamePlayManager>();
        m_Save = FindObjectOfType<SaveManager>();
    }

    private void Update()
    {
        Score.text = "SCORE: " + m_Manager.Points;
        BestScore.text = "BEST SCORE: " + m_Save.MaxPoints;
    }
}
