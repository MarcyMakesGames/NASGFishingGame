using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishPoolUIController : BaseUIElement<int, int>
{
    private Transform targetTransform;
    public override void UpdateUI(int primaryData, int secondaryData)
    {
        if (ClearedIfEmpty(primaryData, secondaryData))
            return;
    }

    public void InitUIController(Transform targetTransform)
    {
        this.targetTransform = targetTransform;
    }

    protected override bool ClearedIfEmpty(int newData, int secondaryData)
    {
        return false;
    }

    private void Update()
    {
        if (targetTransform == null)
            return;

        transform.position = Camera.main.WorldToScreenPoint(targetTransform.position);
    }
}
