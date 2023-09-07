using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _deathMenu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CameraBehaviour._instance._cameraSpeedModifier = 0f;
            _deathMenu.SetActive(true);
            AudioManager._instance._sfxSource.Stop();
            AudioManager._instance.PlaySfxSound(AudioManager._instance._playerDeathSfx);
            AudioManager._instance._musicSource.Stop();
        }
    }
}
