using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Instruction : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }
    }
}
