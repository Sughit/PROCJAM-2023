using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCan : Interactable
{
    public Extinctor ext;
    public override void Interact()
    {
        base.Interact();
            DeleteItems();
    }

    void DeleteItems()
    {
        ChefInventory.instance.items.Clear();
        if(ChefInventory.instance.onItemChangedCallback != null)
            ChefInventory.instance.onItemChangedCallback.Invoke();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {ext.ext2.SetActive(false);

                Extinctor.luatExt = false;
                ext.ext.SetActive(true);}
    }

}
