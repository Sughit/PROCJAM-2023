using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateOrder : MonoBehaviour
{

    #region Singleton

    public static GenerateOrder instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of GenerateOrder found");
            return;
        }

        instance = this; 
    } 

    #endregion

    public delegate void OnOrderChanged();
    public OnOrderChanged onOrderChangedCallback;

    public Item[] totalItems;
    public List<Item> currentOrder = new List<Item>();

    public int minItems;
    public int maxItems;

    void Start()
    {
        MakeOrder();
    }

    public void MakeOrder()
    {
        //seteaza minimul de ingresiente
        for(int i = 0; i < minItems; i++)
        {
            currentOrder.Insert(i, totalItems[Random.Range(0, totalItems.Length)]);
        }

        //sansa de 1 din 5 sa aibe maximul de ingrediente
        if(Random.Range(0, 6) == 3)
        {
            for(int i = minItems; i < maxItems; i++)
            {
                currentOrder.Insert(i, totalItems[Random.Range(0, totalItems.Length)]);
            }
        }

        if(onOrderChangedCallback != null)
            onOrderChangedCallback.Invoke();
    }

    public void RemoveItems(Item item)
    {
        currentOrder.Remove(item);

        if(onOrderChangedCallback != null)
            onOrderChangedCallback.Invoke();
    }
}
