using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FinishOrder : MonoBehaviour
{
    List<Item> order = new List<Item>();
    List<Item> inventory = new List<Item>();

    public GenerateOrder orderScript;
    public ChefInventory inventoryScript;

    public void SortLists()
    {
        order = orderScript.currentOrder.OrderBy(item => item.name).ToList();
        inventory = inventoryScript.items.OrderBy(item => item.name).ToList();
    }

    public bool CompareLists()
    {
        bool correctOrder = true;
        if(order.Count != inventory.Count)
            correctOrder = false;

        for(int i = 0; i < order.Count; i++)
        {
            if(order[i] != inventory[i]) correctOrder = false;
        }

        return correctOrder;
    }
}
