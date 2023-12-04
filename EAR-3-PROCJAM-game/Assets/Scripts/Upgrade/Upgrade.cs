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

    bool setUpgrade = true;

    public List<ChefStats> chefs = new List<ChefStats>();

    void Start()
    {
        if(setUpgrade)
        {
            if(onUpgradeChangedCallback != null)
            onUpgradeChangedCallback.Invoke();
            setUpgrade=false;
        }
    }

    public bool Add(ChefStats chef)
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

    public void Remove(ChefStats chef)
    {
        chefs.Remove(chef);

        if(onUpgradeChangedCallback != null)
            onUpgradeChangedCallback.Invoke();
    }
}
