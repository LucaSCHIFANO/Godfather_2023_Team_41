using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Balloon : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private ScoreRef scoreManager;

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
    [SerializeField] GameObject toSpawn;


    private bool isActivated;

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
        if (!context.started || !isActivated) return;
        currentBallonGauge += increaseBallonGauge;
        AudioManager._instance.PlaySfxSound(AudioManager._instance._baloonGaugingSfx);

        if (currentBallonGauge >= maxBallonGauge)
        {
            AudioManager._instance.PlaySfxSound(AudioManager._instance._balloonExplosionSfx);
            scoreManager.Instance.AddScore(100);
            var spawn = Instantiate(toSpawn, transform.position, transform.rotation);
            Destroy(spawn, 10);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PuzzleActivation")
        {
            isActivated = true;
        }
    }
}
