using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvController : MonoBehaviour
{
    public bool enableOceanChange = false;
    private bool oceanChanged = false;
    private Animation anim;
    private Animation anim2;

private void Start()
{
    anim = gameObject.GetComponent<Animation>();
}
    private void Update()
    {
        if(enableOceanChange)
        {
            ChangeOcean();
        }  
        else
        {
            ReverseOcean();
            anim[anim.clip.name].speed = 1;
            anim[anim.clip.name].time = 0;
        }    
    }
    private void ChangeOcean()
    {
        if(oceanChanged == false)
        {
            anim.Play();
            oceanChanged = true;
        }
    }

    private void ReverseOcean()
    {
        if(oceanChanged == true)
        {
            anim[anim.clip.name].speed = -1;
            anim[anim.clip.name].time = anim.clip.length;
            anim.Play();
            oceanChanged = false;
        }
    }
}
