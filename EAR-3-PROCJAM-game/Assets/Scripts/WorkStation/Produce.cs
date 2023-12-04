using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Produce : MonoBehaviour
{
    public ChefStats chefStats;
    public Item product;
    public GameObject productGO;
    public float timer;
    [HideInInspector]
    public bool canTake;
    public Animator anim;
    public GameObject foc;
    bool onFire;
    public static bool extinguishing;
    int x;
    public GameObject CO2;
    public Extinctor ext;
    public int chanceToFire = 12;
    public GameObject player;
    public GameObject slider;
    bool faceMancare;

    void Awake()
    {
        if(CO2 == null) CO2 = GameObject.Find("bucatarAsamblare/extinctor (1)/particule");
        if(ext == null) ext = GameObject.Find("suport").GetComponent<Extinctor>();
        if(player == null) player = GameObject.Find("bucatarAsamblare");
        timer=chefStats.timeToCook;
    }

    void OnMouseUp()
    {
        Debug.Log("Clicked on ");
        if(!onFire && !extinguishing && !Extinctor.luatExt && !faceMancare)
            MakeProduct();
        else
        {
            if(Extinctor.luatExt && !extinguishing && onFire && Vector3.Distance(player.transform.position, transform.position) <= GetComponent<TakeProduct>().radius)
            {
                StartCoroutine(StingereFoc());
                onFire = false;
                foc.SetActive(false);
                anim.SetBool("luatFoc", false);
                x = 0;
            }
            
        }
    }

    public void MakeProduct()
    {
            if(!canTake)
            {
                //sfx si particule
                anim.SetBool("laMunca", true);
                Debug.Log("Starting to make");
                slider.SetActive(true); 
                slider.GetComponent<Timer>().gameTime = timer;
                slider.GetComponent<Timer>().StartTimer();
                StartCoroutine(MakeProductTimer());
            }
            else
            {
                Debug.Log("Item waiting to be taken");
            }
    }

    IEnumerator MakeProductTimer()
    {
        faceMancare = true;
        x = Random.Range(0,chanceToFire);
        yield return new WaitForSeconds(timer);
        faceMancare = false;
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

    IEnumerator StingereFoc()
    {
        player.GetComponent<ControllingChef>().SetFocus(this.GetComponent<TakeProduct>());
        CO2.SetActive(true);
        extinguishing = true;

        yield return new WaitForSeconds(1);
        CO2.SetActive(false);
        extinguishing = false;

        ext.ext2.SetActive(false);
        Extinctor.luatExt = false;
        ext.ext.SetActive(true);
    }
}

