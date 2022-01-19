using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score = 0;
    private Text scoreText;
    
    void Start()
    {
        //перед тем как мы будем работать с компонентом его нужно присвоить из обьекта
        scoreText = GetComponent<Text>();
        scoreText.text = $"Score : {score.ToString()}";
    }

    public void ScoreHit(int scorePerHit)
    {
        score += scorePerHit;
        scoreText.text = $"Score : {score.ToString()}";
    }
}
