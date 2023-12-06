using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinctor : Interactable
{
    public GameObject ext;
    public GameObject ext2;
    public static bool luatExt = false;
    public GameObject pickUpSFX;

    public override void Interact()
    {
        base.Interact();
        if(!luatExt)
        {
            Instantiate(pickUpSFX);
            ext.SetActive(false);
            ext2.SetActive(true);
            luatExt = true;
        }
        else
        {
            Instantiate(pickUpSFX);
            ext2.SetActive(false);
            ext.SetActive(true);
            luatExt = false;
        }
    }
}
