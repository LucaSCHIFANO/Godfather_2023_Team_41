using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Balloon : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject balloon;
    [SerializeField] Slider slider;


    [Header("BalloonAir")]
    [SerializeField] float maxBallonGauge;
    float currentBallonGauge;
    [SerializeField] float increaseBallonGauge;
    [SerializeField] float decreaseBallonGaugeOverTime;

    [Header("BallonSize")]
    [SerializeField] Vector2 balloonSizeLimits;

    void Start()
    {
        
    }

    void Update()
    {
        currentBallonGauge -= decreaseBallonGaugeOverTime * Time.deltaTime;
        currentBallonGauge = Mathf.Clamp(currentBallonGauge, 0, maxBallonGauge);

        slider.value = currentBallonGauge / maxBallonGauge;
        float size = Mathf.Lerp(balloonSizeLimits.x, balloonSizeLimits.y, currentBallonGauge / maxBallonGauge); ;
        balloon.transform.localScale = new Vector3(size, size, size);   
    }

    public void PumpInput(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        currentBallonGauge += increaseBallonGauge;

        if(currentBallonGauge >= maxBallonGauge)
        {
            Destroy(gameObject);
        }
    }
}
