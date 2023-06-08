using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FishPoolUIController : BaseUIElement<int, int>
{
    [Header("References")]
    [SerializeField] private GameObject fishSpritePrefab;
    [SerializeField] private Transform uiElementAnchor;

    [Header("Settings")]
    [SerializeField] private Color availableFishColor;
    [SerializeField] private Color unavailableFishColor;

    private Transform targetTransform;
    private List<GameObject> fishList;
    
    public override void UpdateUI(int primaryData, int secondaryData)
    {
        if (ClearedIfEmpty(primaryData, secondaryData))
            return;

        if (fishList == null)
            fishList = new List<GameObject>();

        UpdateMaxFishIcons(secondaryData);
        UpdateAvailableFishIcons(primaryData, secondaryData);
    }

    private void UpdateAvailableFishIcons(int primaryData, int secondaryData)
    {
        if(primaryData == 0)
        {
            ClearUI();
            return;
        }

        for (int i = 0; i < secondaryData; i++)
        {
            if (i < primaryData)
                fishList[i].GetComponent<Image>().color = availableFishColor;
            else
                fishList[i].GetComponent<Image>().color = unavailableFishColor;
        }
    }

    private void UpdateMaxFishIcons(int secondaryData)
    {
        if (secondaryData >= fishList.Count)
        {
            int j = fishList.Count;

            for (int i = j; i < secondaryData; i++)
            {
                GameObject fish = Instantiate(fishSpritePrefab, uiElementAnchor);
                fishList.Add(fish);
            }
        }
        else if (secondaryData < fishList.Count)
        {
            int j = fishList.Count;

            for (int i = j - 1; i >= secondaryData; i--)
            {
                Destroy(fishList[i]);
                fishList.RemoveAt(i);
            }
        }
    }

    public void InitUIController(Transform targetTransform)
    {
        this.targetTransform = targetTransform;
        fishList = new List<GameObject>();
    }

    protected override bool ClearedIfEmpty(int newData, int secondaryData)
    {
        if(secondaryData == 0)
        {
            ClearUI();
            return true;
        }

        return false;
    }

    private void Update()
    {
        if (targetTransform == null)
            return;

        transform.position = Camera.main.WorldToScreenPoint(targetTransform.position);
    }

    private void ClearUI()
    {
        if(fishList != null)
            foreach (GameObject fish in fishList)
                Destroy(fish);

        fishList.Clear();
    }
}
