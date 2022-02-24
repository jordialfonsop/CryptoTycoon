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
            money += Time.deltaTime * (PCnum * 10);
        }
        
        if (TimeStart > 2.0)
        {
            myDate=myDate.AddDays(1);
            TimeStart = 0.0;
        }
        timeText.text = myDate.ToString();
        moneyText.text = Math.Ceiling(money).ToString();
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
