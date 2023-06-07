using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CargoCapacityUIController : BaseUIElement<PlayerID, int, int>
{
    [SerializeField] private TMP_Text player1CapacityText;
    [SerializeField] private TMP_Text player2CapacityText;
    [SerializeField] private TMP_Text player3CapacityText;
    [SerializeField] private TMP_Text player4CapacityText;

    public override void UpdateUI(PlayerID primaryData, int secondaryData, int tertiaryData)
    {
        if(ClearedIfEmpty(primaryData, secondaryData, tertiaryData))
            return;

        switch (primaryData)
        {
            case PlayerID.Player1:
                player1CapacityText.text = secondaryData.ToString() + "/" + tertiaryData.ToString();
                break;
            case PlayerID.Player2:
                player2CapacityText.text = secondaryData.ToString() + "/" + tertiaryData.ToString();
                break;
            case PlayerID.Player3:
                player3CapacityText.text = secondaryData.ToString() + "/" + tertiaryData.ToString();
                break;
            case PlayerID.Player4:
                player4CapacityText.text = secondaryData.ToString() + "/" + tertiaryData.ToString();
                break;
        }
    }

    protected override bool ClearedIfEmpty(PlayerID newData, int secondaryData, int tertiaryData)
    {
        if (tertiaryData == 0)
            return true;

        return false;
    }
}
