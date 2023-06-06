using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerAssignment : MonoBehaviour
{
    [SerializeField] private MovementController movementController1;
    [SerializeField] private MovementController movementController2;
    [SerializeField] private MovementController movementController3;
    [SerializeField] private MovementController movementController4;

    private int player1ID;
    private int player2ID;
    private int player3ID;
    private int player4ID;

    public void AssignPlayer(int currentPlayer)
    {
        switch(currentPlayer)
        {

        }
    }
}
