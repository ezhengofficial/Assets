using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreScript : MonoBehaviour
{   
    public static int score;
    public TextMeshProUGUI scoreText;
    
    // Update is called once per frame
    void Start()
    {       
        scoreText = GetComponent<TMPro.TextMeshProUGUI>();
        scoreText.SetText(score.ToString());
    }

    public void Score()
    {
        score += 100;
        Debug.Log("Scored");
        scoreText.SetText(score.ToString());
    }
}
