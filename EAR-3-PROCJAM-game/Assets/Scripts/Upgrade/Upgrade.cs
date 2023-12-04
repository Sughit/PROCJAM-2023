using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    #region Singleton

    public static Upgrade instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Upgrade found");
            return;
        }

        instance = this; 
    } 

    #endregion

    public delegate void OnUpgradeChanged();
    public OnUpgradeChanged onUpgradeChangedCallback;

    public int space = 8;

    public List<Item> chefs = new List<Item>();

    public bool Add(Item chef)
    {
        if(chefs.Count >= space)
        {
            Debug.Log("not enough room");
            return false;
        }
        chefs.Add(chef);

        if(onUpgradeChangedCallback != null)
            onUpgradeChangedCallback.Invoke();

        return true;
    }

    public void Remove(Item chef)
    {
        chefs.Remove(chef);

        if(onUpgradeChangedCallback != null)
            onUpgradeChangedCallback.Invoke();
    }
}
