using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class GlobalControl : MonoBehaviour
{
    private double TimeStart;
    public Text timeText;
    static DateTime myDate;


    public bool isPaused;
    public Image pauseimg;
    public Sprite pauseSprite;
    public Sprite playSprite;


    public double PCnum;
    public Text moneyText;
    public double money;


    public Image PC;
    public Sprite PC1;
    public Sprite PC2;
    public Sprite PC3;
    public Sprite PC4;
    public int temp = 2;



    // Start is called before the first frame update
    void Start()
    {
        myDate = new DateTime (2022,2,24);
        isPaused = false;
        PCnum = 2;
        money = 3000;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            TimeStart += Time.deltaTime;
            
        }
        
        if (TimeStart > 2.0)
        {
            myDate=myDate.AddDays(1);
            TimeStart = 0.0;
            money += PCnum * 100;
        }
        timeText.text = myDate.ToString();
        moneyText.text = Math.Ceiling(money).ToString();
        if (temp == 2)
        {
            PC.sprite = PC1;
        }
        else if (temp == 3)
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


    public void pauseUnpause()
    {
        isPaused = !isPaused;
        if (pauseimg.sprite.name == "GUI_34")
        {
            pauseimg.sprite = playSprite;
            //pause the time
        }
        else
        {
            pauseimg.sprite = pauseSprite;
            //resume the time
        }
    }
}
