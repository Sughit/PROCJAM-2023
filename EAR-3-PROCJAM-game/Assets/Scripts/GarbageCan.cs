using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCan : Interactable
{
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
}
