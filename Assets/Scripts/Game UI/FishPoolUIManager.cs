using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPoolUIManager : MonoBehaviour
{
    [SerializeField] private GameObject fishPoolUIPrefab;
    [SerializeField] private RectTransform rectTransform;
    public FishPoolUIController GetFishPoolUIElement(Transform anchorTransform)
    {
        GameObject fishPoolUIObject = Instantiate(fishPoolUIPrefab, rectTransform);
        FishPoolUIController fishPoolUIController = fishPoolUIObject.GetComponent<FishPoolUIController>();

        fishPoolUIController.InitUIController(anchorTransform);

        return fishPoolUIController;
    }
}
