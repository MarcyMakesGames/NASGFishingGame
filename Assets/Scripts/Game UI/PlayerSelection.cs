using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField]
    private Image bShip;
    [SerializeField]
    private Image gShip;
    [SerializeField]
    private Image rShip;
    [SerializeField]
    private Image yShip;

    private void Update()
    {
        Gamepad[] gamepads = Gamepad.all.ToArray();

        if (gamepads.Length < 1)
        {
            return;
        }

        foreach (Gamepad gamepad in gamepads)
        {
            if (gamepad == Gamepad.all[0])
            {
                // Player 1 code here
                bool player1input = gamepad.buttonSouth.isPressed;

                if (player1input)
                {
                    bShip.gameObject.SetActive(true);
                }
            }
            else if (gamepad == Gamepad.all[1])
            {
                // Player 2 code here
                bool player2input = gamepad.buttonSouth.isPressed;

                if (player2input)
                {
                    gShip.gameObject.SetActive(true);
                }
            }
            else if (gamepad == Gamepad.all[2])
            {
                // Player 3 code here
                bool player3input = gamepad.buttonSouth.isPressed;

                if (player3input)
                {
                    rShip.gameObject.SetActive(true);
                }
            }
            else if (gamepad == Gamepad.all[3])
            {
                // Player 4 code here
                bool player4input = gamepad.buttonSouth.isPressed;

                if (player4input)
                {
                    yShip.gameObject.SetActive(true);
                }
            }
        }    
    }
    public void AddPlayers(PlayerID pID)
    {
        if(Input.anyKeyDown)
        {
            switch (pID)
            {
                case PlayerID.Player1:
                    bShip.gameObject.SetActive(true);
                    break;
                case PlayerID.Player2:
                    gShip.gameObject.SetActive(true);
                    break;
                case PlayerID.Player3:
                    rShip.gameObject.SetActive(true);
                    break;
                case PlayerID.Player4:
                    yShip.gameObject.SetActive(true);
                    break;
            }

        }
    }
}
