using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimeUIController : BaseUIElement<int>
{
    [SerializeField] private TMP_Text timeText;

    public override void UpdateUI(int primaryData)
    {
        if(ClearedIfEmpty(primaryData))
            return;

        int minutes = Mathf.FloorToInt(primaryData / 60);
        int seconds = primaryData % 60;

        if (seconds == 0)
            timeText.text = minutes.ToString() + ":00";
        else
        {
            if (seconds < 10)
            {
                timeText.text = minutes.ToString() + ":0" + seconds.ToString();
            }
            else
                timeText.text = minutes.ToString() + ":" + seconds.ToString();
        }
    }

    protected override bool ClearedIfEmpty(int newData)
    {
        if(newData <= 0)
        {
            ClearUI();
            return true;
        }

        return false;
    }

    private void ClearUI()
    {
        timeText.text = "0:00";
    }
}
