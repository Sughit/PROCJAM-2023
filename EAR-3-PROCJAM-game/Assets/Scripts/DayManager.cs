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
    public Text text;
    public Text text2;

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
            Time.timeScale=0;
            if(numDay % 2 == 0)
            {
                maxOrders++;
            }
        }

        text.text = (numDay+1).ToString();
        text2.text = "Day " +numDay.ToString()+ " ended";


    }

    void EndDay()
    {
        Produce[] prod = FindObjectsOfType<Produce>();
        foreach (var nume in prod)
        {
            nume.canTake = false;
            nume.productGO.SetActive(false);
            nume.onFire=false;
            nume.foc.SetActive(false);
            nume.anim.SetBool("luatFoc", false);
            nume.focSFX.SetActive(false);
            nume.finishSFX.SetActive(false);
            nume.mancareSFX.SetActive(false);
            nume.faceMancare=false;
        }
        dayMenu.SetActive(true);
        numOrders = 0;
        numDay++;
        MoneyScript.instance.CalculateMoney();
    }

    public void NextDay()
    {
        Time.timeScale=1;
        GenerateOrder.instance.currentTimeToNewOrder = GenerateOrder.instance.timeToNewOrder;
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
        if(numDay-1 <= chefs.Count) Upgrade.instance.Add(chefs[numDay-1].GetComponent<Produce>().chefStats);
        GetComponent<GenerateOrder>().MakeOrder();
        MoneyScript.instance.Reset();
        //SceneManager.LoadScene("Main");
    }
}
