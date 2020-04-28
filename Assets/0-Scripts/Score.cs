using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0;


    void OnGUI()
    {
        GUI.Box(new Rect(100, 100, 100, 100), score.ToString());
    }
}
