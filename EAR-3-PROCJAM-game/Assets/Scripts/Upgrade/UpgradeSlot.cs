using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSlot : MonoBehaviour
{
    public Image icon;
    ChefStats chef;

    public void AddItem(ChefStats newChef)
    {
        chef = newChef;

        icon.sprite = chef.icon;
        icon.enabled = true;
    }

    public void UpgradeTimer()
    {
        if(chef != null)
        {
            Debug.Log("Upgrade " + chef.Name + " work rate");
            Produce script=GameObject.Find($"mobilaTest/{chef.Name}").GetComponent<Produce>();
            script.timer=1;
        }
    }

    public void UpgradeFire()
    {
        if(chef != null)
        {
            Debug.Log("Upgrade " + chef.Name + " fire chance");
            Produce script=GameObject.Find($"mobilaTest/{chef.Name}").GetComponent<Produce>();
            script.chanceToFire = 15;
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
