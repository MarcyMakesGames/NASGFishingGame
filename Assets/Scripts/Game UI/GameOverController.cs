using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private Button retryButton;

    // function to be called when the player reaches the game end condition
    public void ShowGameOverUI(List<PlayerID> players)
    {
        gameOverPanel.SetActive(true);
        Debug.Log("Game Over Displayed!");

        if(players.Count == 1)
        {
            messageText.text = players[0].ToString() + " wins!";
        }
        else
        {
            string winText = "";

            for(int i = 0; i < players.Count; i++)
            {
                winText += players[i].ToString()+" ";
                if(i < players.Count - 1)
                    winText += "and ";
            }

            winText += "win!";
            messageText.text = winText;
        }
    }

    private void OnEnable() 
    {
        foreach(PlayerInput player in FindObjectsOfType<PlayerInput>())
        {
            player.SwitchCurrentActionMap("UI");
            EventSystem.current.SetSelectedGameObject(retryButton.gameObject);
        }
    }

    // function to be called when the player restarts the game
    public void HideGameOverUI()
    {
        gameObject.SetActive(false); // deactivate the Game Over object to hide the UI window and components
    }

    private void OnDisable() 
    {
        // something on disable
    }

    public void InitiateRetry()
    {
        Destroy(GameManager.instance.gameObject);

        SceneManager.LoadScene(0);
    }

    public void QuitGame() // Quits the game when you click on Quit button
    {
        Application.Quit();
    }
}
