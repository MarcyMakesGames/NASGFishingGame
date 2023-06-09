using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{ 
    [SerializeField] private Button nGame;
    [SerializeField] private Button exitGame;

    public void StartNewGame()
    {
        //change scene
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void PlayMusic()
    {
        //play menu music
    }
}
