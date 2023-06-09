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
    [TextArea(3, 10)][SerializeField] private string equalityText;
    [TextArea(3, 10)][SerializeField] private string tieText;
    [TextArea(3, 10)][SerializeField] private string singleWinnerText;
    [TextArea(3, 10)][SerializeField] private string nonDepletedText;
    [TextArea(3, 10)][SerializeField] private string depletedText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text winConditionText;
    [SerializeField] private TMP_Text depletionText;
    [SerializeField] private Button retryButton;

    // function to be called when the player reaches the game end condition
    public void ShowGameOverUI(List<PlayerID> players, bool fishDepleted)
    {
        gameOverPanel.SetActive(true);
        Debug.Log("Game Over Displayed!");

        if(players.Count == 1)
        {
            winConditionText.text = players[0].ToString() + singleWinnerText;
        }
        else if(players.Count < 4 && players.Count > 1)
        {
            string winText = "";

            for(int i = 0; i < players.Count; i++)
            {
                winText += players[i].ToString()+" ";
                if(i < players.Count - 1)
                    winText += "and ";
            }

            winText += tieText;

            winConditionText.text = winText;
        }
        else if(players.Count == 4)
        {
            winConditionText.text = equalityText;
        }

        if (fishDepleted)
            depletionText.text = depletedText;
        else
            depletionText.text = nonDepletedText;
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
