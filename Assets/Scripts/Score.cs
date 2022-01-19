using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private int scorePerHit = 10;
    private int score = 0;
    private Text scoreText;
    
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = $"Score : {score.ToString()}";
    }

    public void ScoreHit()
    {
        score += scorePerHit;
        scoreText.text = $"Score : {score.ToString()}";
    }
}
