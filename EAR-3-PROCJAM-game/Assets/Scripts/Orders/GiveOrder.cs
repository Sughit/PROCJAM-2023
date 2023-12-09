using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FinishOrder))]
public class GiveOrder : Interactable
{
    public GenerateOrder generateOrder;
    FinishOrder finish;
    public GameObject sunetClopotel;
    public Animator anim;

    void Start()
    {
        finish = GetComponent<FinishOrder>();
    }

    public override void Interact()
    {
        base.Interact();

        if(ChefInventory.instance.items.Count != 0)
        {
            Give();
            Instantiate(sunetClopotel);
            anim.SetTrigger("clopotel");
        }
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
                generateOrder.currentTimeToNewOrder = generateOrder.timeToNewOrder;
            }
        }
        else
        {
            Debug.Log("Incorrect order");
            MoneyScript.incorrectOrders++;
            DeleteLists();
            generateOrder.MakeOrder();
            generateOrder.currentTimeToNewOrder = generateOrder.timeToNewOrder;
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
