using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distrugeExtinctor : MonoBehaviour
{
    public Extinctor ext;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            ext.ext2.SetActive(false);
            Extinctor.luatExt = false;
            ext.ext.SetActive(true);
        }
    }
}
