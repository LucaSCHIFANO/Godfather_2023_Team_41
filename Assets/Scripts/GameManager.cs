using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    void Start()
    {
        AudioManager._instance.PlaySfxSound(AudioManager._instance._startGameSfx);
    }
}
