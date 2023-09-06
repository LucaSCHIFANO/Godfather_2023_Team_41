using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    [SerializeField] private Reference<Score> scoreManager;
    private float curretnScore;

    void Awake()
    {
        scoreManager.Instance = this;
    }

    void Update()
    {
        
    }
}
