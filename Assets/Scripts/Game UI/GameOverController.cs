using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class GameOverController : MonoBehaviour
{
    private TMP_Text titleText; // 'Game Over' title for the window
    
    [SerializeField]
    private TMP_Text scoreText; // reference to the Text component that will display the final score
    [SerializeField]
    private TMP_Text messageText; // reference to the Text component that will display the rich message

    // function to be called when the player reaches the game end condition
    public void ShowGameOverUI(int finalScore, string richMessage)
    {
        Debug.Log("Game Over Displayed!");
        scoreText.text = "Final Score: \n" + finalScore.ToString(); // display the final score
        messageText.text = richMessage; // display the rich message
        gameObject.SetActive(true); // activate the Game Over window to show the UI elements
    }

    private void OnEnable() 
    {
        //something on enable
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
        // Stuff that happens when you click retry
    }

    public void QuitGame() // Quits the game when you click on Quit button
    {
        Application.Quit();
    }
}
