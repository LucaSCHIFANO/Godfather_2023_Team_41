using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] private GameObject _deathMenu;

    public void ReloadLevel()
    {
        SceneManager.LoadScene(1);
        _deathMenu.SetActive(false);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        _deathMenu.SetActive(false);
    }
}