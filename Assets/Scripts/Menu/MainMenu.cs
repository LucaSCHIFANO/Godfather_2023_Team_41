using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject howToPlay;

    [SerializeField] private GameObject tuto_1;
    [SerializeField] private GameObject tuto_2;
    private bool isTuto2;

    // Start is called before the first frame update
    void Awake()
    {
        BackToMain();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToHTP()
    {
        mainMenu.SetActive(false);
        howToPlay.SetActive(true);
    }

    public void BackToMain()
    {
        mainMenu.SetActive(true);
        howToPlay.SetActive(false);
    }

    public void Quit()
    {
       /* if(Application.isEditor) EditorApplication.isPlaying = false;
        else */Application.Quit();
    }

    public void ChangeTuto()
    {
        if (isTuto2)
        {
            tuto_1.SetActive(true);
            tuto_2.SetActive(false);
            isTuto2 = false;
        }
        else
        {
            tuto_1.SetActive(false);
            tuto_2.SetActive(true);
            isTuto2 = true;
        }
    }
}
