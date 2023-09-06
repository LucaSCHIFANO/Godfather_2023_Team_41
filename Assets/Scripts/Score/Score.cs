using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private Reference<Score> scoreManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int currentScore;

    void Awake()
    {
        scoreManager.Instance = this;
        currentScore = 0;
        ActualizeScore();
    }

    void Update()
    {
        
    }

    public void AddScore(int score)
    {
        currentScore += score;
        ActualizeScore();
    }

    void ActualizeScore()
    {
        scoreText.text = $"Score : {currentScore.ToString("00000")}";
    }
}
