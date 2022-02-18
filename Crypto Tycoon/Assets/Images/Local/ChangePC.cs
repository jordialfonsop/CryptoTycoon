using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ChangePC : MonoBehaviour
{
    //public GameObject Global = GameObject.FindWithTag("SceneControl");
    public SpriteRenderer PC;
    public Sprite PC1;
    public Sprite PC2;
    public Sprite PC3;
    public Sprite PC4;
    public int temp=2;


    void Update()
    {
        if (temp == 2)
        {
            PC.sprite = PC1;
        }else if (temp == 3)
        {
            PC.sprite = PC2;
        }
        else if (temp == 4)
        {
            PC.sprite = PC3;
        }
        else if (temp == 5)
        {
            PC.sprite = PC4;
        }

    }

}
