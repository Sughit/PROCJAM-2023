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
    public GameObject foc;
    bool onFire;
    int x;

    void OnMouseUp()
    {
        Debug.Log("Clicked on ");
        if(!onFire)
            MakeProduct();
        else
        {
            onFire = false;
            foc.SetActive(false);
            anim.SetBool("luatFoc", false);
            x = 0;
        }
    }

    public void MakeProduct()
    {
            if(!canTake)
            {
                //sfx si particule
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
        x = Random.Range(0,12);
        yield return new WaitForSeconds(timer);
        if(x != 1)
        {
            productGO.SetActive(true);
            canTake = true;
            anim.SetBool("laMunca", false);
            Debug.Log("Finished");
            //sunet finalizat
        }
        else
        {
            onFire = true;
            foc.SetActive(true);
            anim.SetBool("luatFoc", true);
            anim.SetBool("laMunca", false);
        }
        
    }
}
