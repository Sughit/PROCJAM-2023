using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSlot : MonoBehaviour
{
    public Image icon;
    ChefStats chef;

    public Text timerText;
    public Text fireText;

    public void AddItem(ChefStats newChef)
    {
        chef = newChef;

        icon.sprite = chef.icon;
        icon.enabled = true;

        timerText.gameObject.SetActive(true);
        fireText.gameObject.SetActive(true);
    }

    public void UpgradeTimer()
    {
        if(chef != null)
        {
            Debug.Log("Upgrade " + chef.Name + " work rate");
            Produce script=GameObject.Find($"mobilaTest/{chef.Name}").GetComponent<Produce>();
            if(!script.timerI && !script.timerII && !script.timerIII) 
            {
                if(MoneyScript.money >= 5)
                {
                    script.timerI=true;
                    timerText.text="10";
                    MoneyScript.money -= 5;
                }
            }
            else if(script.timerI)
            {
                if(MoneyScript.money >= 10)
                {
                    script.timerI=false;
                    script.timerII=true;
                    timerText.text="15";
                    MoneyScript.money -= 10;
                }
            }
            else if(script.timerII)
            {
                if(MoneyScript.money >= 15)
                {
                    script.timerII=false;
                    script.timerIII=true;
                    timerText.text="Max";
                    MoneyScript.money -= 15;
                }
            }
            script.SetUpgrades();
        }
    }

    public void UpgradeFire()
    {
        if(chef != null)
        {
            Debug.Log("Upgrade " + chef.Name + " fire chance");
            Produce script=GameObject.Find($"mobilaTest/{chef.Name}").GetComponent<Produce>();
            if(!script.fireI && !script.fireII && !script.fireIII) 
            {
                if(MoneyScript.money >= 5)
                {
                    script.fireI=true;
                    timerText.text="10";
                    MoneyScript.money -= 5;
                }
            }
            else if(script.fireI)
            {
                if(MoneyScript.money >= 10)
                {
                    script.fireI=false;
                    script.fireII=true;
                    fireText.text="15";
                    MoneyScript.money -= 10;
                }
            }
            else if(script.fireII)
            {
                if(MoneyScript.money >= 15)
                {
                    script.fireII=false;
                    script.fireIII=true;
                    fireText.text="Max";
                    MoneyScript.money -= 15;
                }
            }
            script.SetUpgrades();
        }
    }

    public void ClearSlot()
    {
        chef =null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void OnRemoveButton()
    {
        Upgrade.instance.Remove(chef);
    }
}
