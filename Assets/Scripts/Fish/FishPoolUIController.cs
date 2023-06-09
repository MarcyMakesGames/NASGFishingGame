using System;
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
    [SerializeField] private float flashSpeed;

    private Transform targetTransform;
    private List<GameObject> fishList;
    private List<GameObject> unavailableFishList;
    private bool fadeOut = true;
    private float currentFlashSpeed;
    
    public override void UpdateUI(int primaryData, int secondaryData)
    {
        if (ClearedIfEmpty(primaryData, secondaryData))
            return;

        UpdateMaxFishIcons(secondaryData);
        UpdateAvailableFishIcons(primaryData, secondaryData);
    }

    public void InitUIController(Transform targetTransform)
    {
        this.targetTransform = targetTransform;
        fishList = new List<GameObject>();
    }

    private void Update()
    {
        FlashRechargeIcons();
        MoveToPoolWorldPosition();
    }

    private void MoveToPoolWorldPosition()
    {
        if (targetTransform == null)
            return;

        transform.position = Camera.main.WorldToScreenPoint(targetTransform.position);

        //var pointA = Camera.main.WorldToScreenPoint(targetTransform.position);
        //Debug.Log("Point A" +pointA);
        //var pointB = Camera.main.WorldToScreenPoint(fishList[fishList.Count - 1].transform.position);
        //Debug.Log("Point B" +pointB);

        //var pointC = (pointB - pointA) / 2;
        //Debug.Log("Point C" +pointC);
        //throw new NotImplementedException();
        //transform.position = pointC;
    }

    protected override bool ClearedIfEmpty(int newData, int secondaryData)
    {
        if (fishList == null)
            fishList = new List<GameObject>();

        if (unavailableFishList == null)
            unavailableFishList = new List<GameObject>();

        if (secondaryData == 0)
        {
            ClearUI();
            return true;
        }

        return false;
    }

    private void FlashRechargeIcons()
    {
        if(fadeOut)
        {
            currentFlashSpeed -= Time.deltaTime * flashSpeed;

            foreach (GameObject fish in unavailableFishList)
                fish.GetComponent<Image>().color = 
                                            new Color(unavailableFishColor.r, 
                                            unavailableFishColor.g, 
                                            unavailableFishColor.b, 
                                            currentFlashSpeed * unavailableFishColor.a);

            if (currentFlashSpeed <= 0)
                fadeOut = false;
        }
        else
        {
            currentFlashSpeed += Time.deltaTime * flashSpeed;

            foreach (GameObject fish in unavailableFishList)
                fish.GetComponent<Image>().color =
                                            new Color(unavailableFishColor.r,
                                            unavailableFishColor.g,
                                            unavailableFishColor.b,
                                            currentFlashSpeed * unavailableFishColor.a);

            if (currentFlashSpeed >= flashSpeed)
                fadeOut = true;
        }
    }

    private void UpdateAvailableFishIcons(int primaryData, int secondaryData)
    {
        unavailableFishList.Clear();

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
            {
                fishList[i].GetComponent<Image>().color = unavailableFishColor;
                unavailableFishList.Add(fishList[i]);
            }
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

    private void ClearUI()
    {
        if(fishList != null)
            foreach (GameObject fish in fishList)
                Destroy(fish);

        fishList.Clear();
    }
}
