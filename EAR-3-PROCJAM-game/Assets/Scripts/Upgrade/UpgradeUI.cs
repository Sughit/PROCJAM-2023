using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    public Transform chefsParent;

    Upgrade upgrade;

    UpgradeSlot[] slots;

    void Start()
    {
        upgrade = Upgrade.instance;
        upgrade.onUpgradeChangedCallback += UpdateUI;

        slots = chefsParent.GetComponentsInChildren<UpgradeSlot>();
        UpdateUI();
    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < upgrade.chefs.Count)
            {
                slots[i].AddItem(upgrade.chefs[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
