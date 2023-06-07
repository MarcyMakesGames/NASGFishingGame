using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpUIController : BaseUIElement<PopUpType>
{
    [Header("Sprites")]
    [SerializeField] private Sprite speedSprite;
    [SerializeField] private Sprite cargoSprite;
    [SerializeField] private Sprite fishSprite;

    [Header("Image Renderers")]
    [SerializeField] private SpriteRenderer popUpSpriteRenderer;
    [SerializeField] private SpriteRenderer popUpBackgroundRenderer;

    [Header("Pop Up Settings")]
    [SerializeField] private float popUpDuration = 3;
    [SerializeField] private float popUpFadeOutDuration = 1;

    [Header("References")]
    [SerializeField] private ShipHoldController shipHoldController;
    [SerializeField] private PopUpType testPopUp;

    private float currentPopUpTime = 0;
    private float currentFadeOutTime = 0;

    [ContextMenu("Test Popup")]
    public void UpdateUI()
    {
        UpdateUI(testPopUp);
    }

    public override void UpdateUI(PopUpType primaryData)
    {
        if(ClearedIfEmpty(primaryData))
            return;

        switch(primaryData)
        {             
            case PopUpType.SpeedIncrease:
                popUpSpriteRenderer.sprite = speedSprite;
                break;
            case PopUpType.CargoIncrease:
                popUpSpriteRenderer.sprite = cargoSprite;
                break;
        }

        popUpSpriteRenderer.color = new Color(1, 1, 1, 1);
        popUpBackgroundRenderer.color = new Color(1, 1, 1, 1);

        currentPopUpTime = popUpDuration;
    }

    protected override bool ClearedIfEmpty(PopUpType newData)
    {
        if(newData == PopUpType.None)
            return true;

        return false;
    }

    private void Update()
    {
        PopUpDurationCountdown();
        PopUpFadeOut();
    }

    private void PopUpDurationCountdown()
    {
        if (currentPopUpTime > 0)
        {
            currentPopUpTime -= Time.deltaTime;

            if (currentPopUpTime <= 0)
            {
                currentPopUpTime = 0;
                currentFadeOutTime = popUpFadeOutDuration;
            }
        }
    }

    private void PopUpFadeOut()
    {
        currentFadeOutTime -= Time.deltaTime;

        if (currentPopUpTime <= 0)
        {
            popUpSpriteRenderer.color = new Color(popUpSpriteRenderer.color.r,
                                                  popUpSpriteRenderer.color.g,
                                                  popUpSpriteRenderer.color.b, 
                                                  currentFadeOutTime / popUpFadeOutDuration);

            popUpBackgroundRenderer.color = new Color(popUpBackgroundRenderer.color.r,
                                                  popUpBackgroundRenderer.color.g,
                                                  popUpBackgroundRenderer.color.b,
                                                  currentFadeOutTime / popUpFadeOutDuration);
        }
    }
}
