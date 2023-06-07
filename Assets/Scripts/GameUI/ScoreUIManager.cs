using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUIManager : MonoBehaviour
{
    [SerializeField] private ScoreUIController player1ScoreUIController;
    [SerializeField] private ScoreUIController player2ScoreUIController;
    [SerializeField] private ScoreUIController player3ScoreUIController;
    [SerializeField] private ScoreUIController player4ScoreUIController;

    public void UpdateScore(PlayerID player, int score)
    {
        switch(player)
        {
            case PlayerID.Player1:
                player1ScoreUIController.UpdateUI(score);
                break;

            case PlayerID.Player2:
                player2ScoreUIController.UpdateUI(score);
                break;

            case PlayerID.Player3:
                player3ScoreUIController.UpdateUI(score);
                break;

            case PlayerID.Player4:
                player4ScoreUIController.UpdateUI(score);
                break;

            default:
                return;
        }
    }
}
