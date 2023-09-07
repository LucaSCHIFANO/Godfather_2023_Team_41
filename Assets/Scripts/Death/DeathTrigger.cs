using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private DeathUiRef deathCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CameraBehaviour._instance._cameraSpeedModifier = 0f;
            PlayerMovement._instance._speedModifier = 0f;
            AudioManager._instance._sfxSource.Stop();
            AudioManager._instance.PlaySfxSound(AudioManager._instance._playerDeathSfx);
            AudioManager._instance._musicSource.Stop();
            deathCanvas.Instance.gameOver();

        }
    }
}
