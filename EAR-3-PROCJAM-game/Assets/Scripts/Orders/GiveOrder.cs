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
            MoneyScript.correctOrders++;
            DeleteLists();
            DayManager.numOrders++;
            if(DayManager.numOrders != DayManager.maxOrders)
            {
                generateOrder.MakeOrder();
            }
        }
        else
        {
            Debug.Log("Incorrect order");
            MoneyScript.incorrectOrders++;
            DeleteLists();
            generateOrder.MakeOrder();
        }
    }

    void DeleteLists()
    {
        ChefInventory.instance.items.Clear();
        if(ChefInventory.instance.onItemChangedCallback != null)
            ChefInventory.instance.onItemChangedCallback.Invoke();
        GenerateOrder.instance.currentOrder.Clear();
    }
}
