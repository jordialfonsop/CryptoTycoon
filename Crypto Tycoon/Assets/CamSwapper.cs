using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwapper : MonoBehaviour
{

    public void swapCam(GameObject from, GameObject to)
    {
        from.SetActive(false);
        to.SetActive(true);

    }
}
