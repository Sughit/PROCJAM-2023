using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayManager : MonoBehaviour
{
    public static int maxOrders = 3;
    public static int numOrders;
    public static int numDay;

    public GameObject dayMenu;
    public GameObject transition;

    public List<GameObject> chefs = new List<GameObject>();
    public List<Item> ingredients = new List<Item>();

    public GenerateOrder generateOrder;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        if(dayMenu == null) dayMenu = GameObject.Find("Canvas/dayMenu");
        if(transition == null) transition = GameObject.Find("Canvas/transition");
    }

    void Update()
    {
        if(numOrders == maxOrders)
        {
            EndDay();
            if(numDay % 3 == 0)
            {
                maxOrders++;
            }
        }

    }

    void EndDay()
    {
        dayMenu.SetActive(true);
        numOrders = 0;
        numDay++;
        MoneyScript.instance.CalculateMoney();
    }

    public void NextDay()
    {
        dayMenu.SetActive(false);
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        Animator transitionAnim=transition.GetComponent<Animator>();
        transitionAnim.SetTrigger("trans");
        yield return new WaitForSeconds(0.5f);
        chefs[numDay-1].SetActive(true);
        generateOrder.totalItems.Add(ingredients[numDay-1]);
        Upgrade.instance.Add(chefs[numDay-1].GetComponent<Produce>().chefStats);
        GetComponent<GenerateOrder>().MakeOrder();
        MoneyScript.instance.Reset();
        //SceneManager.LoadScene("Main");
    }
}
