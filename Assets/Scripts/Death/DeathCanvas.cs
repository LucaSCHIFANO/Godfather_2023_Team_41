using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCanvas : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    [Header("Ref")]
    [SerializeField] private DeathUiRef deathCanvas;   
    [SerializeField] private ScoreRef scoreRef;

    void Awake()
    {
        deathCanvas.Instance = this;
    }

    public void gameOver()
    {
        gameOverMenu.SetActive(true);
        scoreText.text = scoreRef.Instance.GetCurrentScore().ToString("00000");
    }
}
