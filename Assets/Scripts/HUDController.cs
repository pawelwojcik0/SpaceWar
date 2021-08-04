using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HUDController : MonoBehaviour
{

   public TMPro.TextMeshProUGUI PointsText;

   public void UpdatePoints(int points)
    {
        PointsText.text = "" + points; 
    }

}
