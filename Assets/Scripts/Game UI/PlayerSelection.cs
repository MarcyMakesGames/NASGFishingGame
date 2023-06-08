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
        Sprite[] childSprites = gameObject.GetComponentsInChildren<Sprite>();
        /*foreach(Sprite spriteComponents in childSprites)
        {
            spriteComponents.gameObject.transform.parent.gameObject.SetActive(true);
        }*/
    }
}
