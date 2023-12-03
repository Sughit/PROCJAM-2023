using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinctor : Interactable
{
    public GameObject ext;
    public GameObject ext2;
    public static bool luatExt = false;

    public override void Interact()
    {
        base.Interact();

        ext.SetActive(false);
        ext2.SetActive(true);

        luatExt = true;
    }
}
