using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUIController : BaseUIElement<int>
{
    [SerializeField] private TMP_Text scoreText;

    public override void UpdateUI(int primaryData)
    {
        if(ClearedIfEmpty(primaryData))
            UpdateText(scoreText, primaryData.ToString());
    }

    protected override bool ClearedIfEmpty(int newData)
    {
        return true;
    }
}
