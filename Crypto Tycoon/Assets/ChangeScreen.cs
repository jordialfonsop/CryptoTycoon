using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeScreen : MonoBehaviour
{
    public GameObject from;
    public GameObject to;
    
 

    public void ChangeScreenFun()
    {
        from.SetActive(false);
        to.SetActive(true);
    }
}
