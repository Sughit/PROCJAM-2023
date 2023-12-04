using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour
{
    public static int money;
    public static int moneyMade;
    public static int lostMoney;
    public static int correctOrders;
    public static int incorrectOrders;
    public static int thrownFood;

    public Text totalMoneyText;
    public Text moneyMadeText;
    public Text lostMoneyText;

    #region Singleton

    public static MoneyScript instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of MoneyScript found");
            return;
        }

        instance = this; 
    } 

    #endregion

    public void CalculateMoney()
    {
        money += correctOrders * 15 - incorrectOrders * 5 - thrownFood * 2 - 10/*salarii*/;
        totalMoneyText.text=$"Total money: {money}";
        moneyMade = correctOrders * 15 - incorrectOrders * 5 - thrownFood * 2 - 10/*salarii*/;
        moneyMadeText.text=$"Money made: {moneyMade}";
        lostMoney = incorrectOrders * 5 + thrownFood * 2 + 10/*salarii*/;
        lostMoneyText.text = $"Lost money: {lostMoney}";
    }

    public void Reset()
    {
        moneyMade=0;
        lostMoney=0;
        correctOrders=0;
        incorrectOrders=0;
    }
}
