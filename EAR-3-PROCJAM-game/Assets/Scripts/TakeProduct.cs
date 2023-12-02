using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Produce))]
public class TakeProduct : Interactable
{
    Produce produce;
    [SerializeField]
    ChefInventory inventory;

    void Start()
    {
        produce = GetComponent<Produce>();
        if(inventory == null)
        {
            GameObject.Find("GameManager").GetComponent<ChefInventory>();
        }
    }
    
    public override void Interact()
    {
        base.Interact();

        Take();
    }

    void Take()
    {
        if(produce.canTake)
        {
            inventory.Add(produce.product);
            produce.canTake = false;
        }
    }
}
