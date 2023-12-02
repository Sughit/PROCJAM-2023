using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderUI : MonoBehaviour
{
    public Transform itemsParent;

    GenerateOrder order;

    OrderSlot[] slots;

    void Start()
    {
        order = GenerateOrder.instance;
        order.onOrderChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<OrderSlot>();
    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < order.currentOrder.Count)
            {
                slots[i].AddItem(order.currentOrder[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
