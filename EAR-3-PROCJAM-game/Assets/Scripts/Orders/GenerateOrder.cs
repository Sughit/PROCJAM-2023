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

    public List<Item> totalItems = new List<Item>();
    public List<Item> currentOrder = new List<Item>();

    public int minItems;
    public int maxItems;

    public float timeToNewOrder;
    [HideInInspector]
    public float currentTimeToNewOrder;
    public GameObject slider;

    void Start()
    {
        currentTimeToNewOrder = timeToNewOrder;
        slider.GetComponent<SliderOrder>().gameTime = timeToNewOrder;
        slider.GetComponent<SliderOrder>().StartTimer();
        MakeOrder();
    }

    void Update()
    {
        if(currentTimeToNewOrder <= 0)
        {
            currentTimeToNewOrder = timeToNewOrder;
            MoneyScript.incorrectOrders++;
            currentOrder.Clear();
            if(onOrderChangedCallback != null)
                onOrderChangedCallback.Invoke();
            slider.GetComponent<SliderOrder>().gameTime = timeToNewOrder;
            slider.GetComponent<SliderOrder>().StartTimer();
            MakeOrder();
        }
        else
        {
            currentTimeToNewOrder -= Time.deltaTime;
        }
        slider.GetComponent<SliderOrder>().gameTime = currentTimeToNewOrder;
    }

    public void MakeOrder()
    {
        //seteaza minimul de ingrediente
        for(int i = 0; i < minItems; i++)
        {
            currentOrder.Insert(i, totalItems[Random.Range(0, totalItems.Count)]);
        }

        //sansa de 1 din 5 sa aibe maximul de ingrediente
        if(Random.Range(0, 6) == 3)
        {
            for(int i = minItems; i < maxItems; i++)
            {
                currentOrder.Insert(i, totalItems[Random.Range(0, totalItems.Count)]);
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
