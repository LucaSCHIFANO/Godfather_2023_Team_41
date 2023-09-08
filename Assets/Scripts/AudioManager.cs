using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _instance;

    [Header("Audio Sources")]
    public AudioSource _musicSource;
    public AudioSource _sfxSource;

    [Space]
    [Header("Audio Clips")]
    [SerializeField] private AudioClip _mainMenuMusic;
    [SerializeField] private AudioClip _gameplayMusic;

    [Space]
    [Header("SFX Clips")]
    public AudioClip _startGameSfx;
    public AudioClip _playerDeathSfx;
    public AudioClip _balloonExplosionSfx;
    public AudioClip _doorOpeningSfx;

    [Space]
    [Header("References")]
    [SerializeField] private GameObject _musicSourceObject;
    [SerializeField] private GameObject _sfxSrouceObject;

    [Space]
    [Header("Variables")]
    [SerializeField] private int _currentSceneIndex;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    void Start()
    {
        _musicSourceObject = GameObject.FindGameObjectWithTag("MusicSource");

        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(_currentSceneIndex);

        if (_currentSceneIndex == 0)
        {
            _musicSource.clip = _mainMenuMusic;
            _musicSource.Play();
        }
        else if (_currentSceneIndex == 1)
        {
            _musicSource.clip = _gameplayMusic;
            _musicSource.Play();
        }
    }

    public void PlaySfxSound(AudioClip _clip)
    {
        _sfxSource.PlayOneShot(_clip);
    }
}
