using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DonDestroyOnLoad : MonoBehaviour
{
    public new string tag;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            DestroyImmediate(this.gameObject);
        }
    }
}

