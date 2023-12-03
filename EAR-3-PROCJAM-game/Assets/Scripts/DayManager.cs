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

    void Update()
    {
        if(numOrders == maxOrders)
        {
            EndDay();
        }
    }

    void EndDay()
    {
        dayMenu.SetActive(true);
        numOrders = 0;
        numDay++;
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
        SceneManager.LoadScene("Main");
    }
}
