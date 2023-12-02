using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FinishOrder))]
public class GiveOrder : Interactable
{
    public GenerateOrder generateOrder;
    FinishOrder finish;

    void Start()
    {
        finish = GetComponent<FinishOrder>();
    }

    public override void Interact()
    {
        base.Interact();

        Give();
    }

    void Give()
    {
        finish.SortLists();

        if(finish.CompareLists())
        {
            Debug.Log("Correct order");
            //mai multi bani
            //DeleteLists();
            generateOrder.MakeOrder();
        }
        else
        {
            Debug.Log("Incorrect order");
            generateOrder.MakeOrder();
        }
    }

    void DeleteLists()
    {
        foreach(var item in ChefInventory.instance.items)
        {
            ChefInventory.instance.Remove(item);
        }
    }
}
