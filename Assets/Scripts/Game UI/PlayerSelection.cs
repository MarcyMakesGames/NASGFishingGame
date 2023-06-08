using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField]
    private Sprite bShip;
    [SerializeField]
    private Sprite gShip;
    [SerializeField]
    private Sprite rShip;
    [SerializeField]
    private Sprite yShip;

    private void OnEnable() 
    {
        SpriteRenderer[] childSprites = gameObject.GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer spriteComponents in childSprites)
        {
            spriteComponents.gameObject.SetActive(true);
        }
    }
}
