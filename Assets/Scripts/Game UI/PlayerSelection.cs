using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer bShip;
    [SerializeField]
    private SpriteRenderer gShip;
    [SerializeField]
    private SpriteRenderer rShip;
    [SerializeField]
    private SpriteRenderer yShip;

    private void Update()
    {
                
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
