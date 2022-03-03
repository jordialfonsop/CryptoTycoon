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


    public GameObject MailBackground;
    public GameObject Mail1;
    public GameObject Mail2;
    public GameObject Mail3;




    public Text mailText;
    public double numberOfMails;

    public GameObject NotEnoughMoney;
    private double warningTime;

    public Text AmazonMiningPCDescription;

    
    
    



    // Start is called before the first frame update
    void Start()
    {
        myDate = new DateTime (2022,2,24);
        isPaused = false;
        PCnum = 2;
        money = 3000;
        Mail1.SetActive(false);
        Mail2.SetActive(false);
        Mail3.SetActive(false);
        numberOfMails = 0;
        warningTime = 0;
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
        AmazonMiningPCDescription.text = "New mining Computer (" + temp.ToString() + "/5 installed)\nPrice: 3000$";
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

        if(temp>3 && MailBackground.activeInHierarchy)
        {
            Mail1.SetActive(true);

        }
        else
        {
            Mail1.SetActive(false);
        }
        mailText.text = numberOfMails.ToString();

        if (temp > 3)
        {
            numberOfMails = 1;
        }
        if (NotEnoughMoney.activeInHierarchy)
        {
            warningTime += Time.deltaTime;
        }
        if (warningTime > 0.7)
        {
            NotEnoughMoney.SetActive(false);
            warningTime = 0;
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

    public void buyMiningPC()
    {
        if (money < 3000 || temp>4)
        {
            
            NotEnoughMoney.SetActive(true);

        }
        else
        {
            temp += 1;
            money -= 3000;
        }
    }
}
