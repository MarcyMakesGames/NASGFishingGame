using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPoolUIManager : MonoBehaviour
{
    [SerializeField] private GameObject fishPoolUIPrefab;

    public FishPoolUIController GetFishPoolUIElement(Transform anchorTransform)
    {
        GameObject fishPoolUIObject = Instantiate(fishPoolUIPrefab, this.transform);

        FishPoolUIController fishPoolUIController = fishPoolUIObject.GetComponent<FishPoolUIController>();

        fishPoolUIController.InitUIController(anchorTransform);

        return fishPoolUIController;
    }
}
