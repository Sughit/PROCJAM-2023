using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSlot : MonoBehaviour
{
    public Image icon;
    Item chef;

    public void AddItem(Item newChef)
    {
        chef = newChef;

        icon.sprite = chef.icon;
        icon.enabled = true;
    }

    public void UpgradeChef()
    {
        if(chef != null)
        {
            Debug.Log("Upgrade");
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
