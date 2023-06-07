using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText; // reference to the Text component that will display the final score
    private TMP_Text titleText; // reference to the Text component that will display the rich message
    [SerializeField]
    private TMP_Text messageText;

    // function to be called when the player reaches the game end condition
    public void ShowGameOverUI(int finalScore, string richMessage)
    {
        scoreText.text = "Final Score: \n" + finalScore.ToString(); // display the final score
        messageText.text = richMessage; // display the rich message
        gameObject.SetActive(true); // activate the GameOverUI object to show the UI elements
    }

    // function to be called when the player restarts the game
    public void HideGameOverUI()
    {
        gameObject.SetActive(false); // deactivate the GameOverUI object to hide the UI elements
    }
}
