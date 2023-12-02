using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Produce : MonoBehaviour
{
    public Item product;
    public GameObject productGO;
    public float timer;
    public bool canTake;
    public Animator anim;

    void OnMouseUp()
    {
        Debug.Log("Clicked on ");
        MakeProduct();
    }

    public void MakeProduct()
    {
        if(!canTake)
        {
            //sfx si particule
            //animatie
            anim.SetBool("laMunca", true);
            Debug.Log("Starting to make");
            StartCoroutine(MakeProductTimer());
        }
        else
        {
            Debug.Log("Item waiting to be taken");
        }
    }

    IEnumerator MakeProductTimer()
    {
        yield return new WaitForSeconds(timer);
        productGO.SetActive(true);
        canTake = true;
        anim.SetBool("laMunca", false);
        Debug.Log("Finished");
        //sunet finalizat
    }
}
