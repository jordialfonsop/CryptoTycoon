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

    public double maxConected;
    public double repeaterNum;


    public Text mailText;
    public double numberOfMails;

    public GameObject NotEnoughMoney;
    private double warningTime;

    public Text AmazonMiningPCDescription;

    public GameObject buyRepeaterButton;
    public GameObject repeaterStandBy;
    public Text buyRepeaterTxt;
    public GameObject AmazonBackgroung;
    public double repeaterPrice;


    public Text DisconectedPcText;
    public double DisconectedPc;

    public double energyCapacity;
    public double wifiCapacity;

    public double daysPassed;
    public double economicTax;
    public double miningPCPrice;
    public double energyPricePerDay;
    public double periodForTax;


    

    public bool eventMail1;
    public bool eventMail2;
    public bool eventMail3;

    public double PCstorageRoom;
    public Text pcNumText;


    public bool IsEnergyPlanPlus;
    public double energyPower;
    public double cryptoPowerNecesity;
    public double cryptoCurrencyPrice;

    public GameObject UpradeEnergyButton;
    public GameObject EnergyPlanTemp;
    public GameObject EnergyScreen;
    public int daysInEnergyPlus;
    public GameObject DowngradeEnergyButton;
    public GameObject EnergyDowngradeTemp;
    public Text EnergyBasicText;
    public Text EnergyPlusText;
    public double ConsumedEnergy;



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
        maxConected = 4;
        repeaterNum = 0;
        repeaterPrice = 500;
        miningPCPrice = 3000;
        DisconectedPc = 0;
        wifiCapacity = 4;
        daysPassed = 0;
        economicTax = 1;
        energyPricePerDay = 50;
        periodForTax = 30;
        cryptoCurrencyPrice = 100;
        cryptoPowerNecesity = 10;
        energyPower = 50;
        eventMail1 = false;
        eventMail2 = false;
        eventMail3 = false;
        PCstorageRoom = 5;
        IsEnergyPlanPlus = false;
        daysInEnergyPlus = 0;


    }

    // Update is called once per frame
    void Update()
    {

        energyCapacity = energyPower / cryptoPowerNecesity;
        if (periodForTax < 1)
        {
            periodForTax = 1;
        }
        maxConected = Math.Min(energyCapacity, wifiCapacity);
        if (!isPaused)
        {
            TimeStart += Time.deltaTime;
            
        }
        
        if (TimeStart > 2.0)
        {
            myDate=myDate.AddDays(1);
            TimeStart = 0.0;
            money += Math.Min(temp, maxConected) * cryptoCurrencyPrice-energyPricePerDay;
            daysPassed += 1;
            if (IsEnergyPlanPlus)
            {
                daysInEnergyPlus+=1;
            }
        }

        if(daysInEnergyPlus>10)
        {
            IsEnergyPlanPlus = false;
            daysInEnergyPlus = 0;
        }


        if(EnergyScreen.activeInHierarchy && !IsEnergyPlanPlus)
        {
            UpradeEnergyButton.SetActive(true);
            EnergyPlanTemp.SetActive(false);
            DowngradeEnergyButton.SetActive(false);
            EnergyDowngradeTemp.SetActive(true);

        }
        else if (EnergyScreen.activeInHierarchy)
        {
            UpradeEnergyButton.SetActive(false);
            EnergyPlanTemp.SetActive(true);
            DowngradeEnergyButton.SetActive(true);
            EnergyDowngradeTemp.SetActive(false);
        }
        else{
            UpradeEnergyButton.SetActive(false);
            EnergyPlanTemp.SetActive(false);
            DowngradeEnergyButton.SetActive(false);
            EnergyDowngradeTemp.SetActive(false);

        }


        timeText.text = myDate.ToString();
        moneyText.text = Math.Ceiling(money).ToString();
        AmazonMiningPCDescription.text = "New mining Computer (" + temp.ToString() + "/"+PCstorageRoom.ToString()+" installed)\nPrice: "+miningPCPrice.ToString()+"$";
        buyRepeaterTxt.text = "New wifi repeater(you can connect " + wifiCapacity.ToString() + " computers to the internet )\nPrice: "+repeaterPrice.ToString()+"$";
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
            eventMail1 = true;
        }
        else if (temp == 5)
        {
            PC.sprite = PC4;
            eventMail2 = true;
        }

        if(eventMail1 && MailBackground.activeInHierarchy)
        {
            Mail1.SetActive(true);

        }
        else
        {
            Mail1.SetActive(false);
        }
        mailText.text = numberOfMails.ToString();

        if (eventMail1&&!eventMail2)
        {
            numberOfMails = 1;
        }else if(eventMail2){
            numberOfMails = 2;
        }


        if (eventMail2 && MailBackground.activeInHierarchy)
        {
            Mail2.SetActive(true);

        }
        else
        {
            Mail2.SetActive(false);
        }

        if (daysPassed >periodForTax)
        {
            daysPassed = 0;
            economicTax = economicTax * 1.1;

            miningPCPrice = miningPCPrice * economicTax;
            repeaterPrice = repeaterPrice * economicTax;
            energyPricePerDay = energyPricePerDay * economicTax;
            periodForTax = periodForTax / 1.05;
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

        if (temp < 5 && AmazonBackgroung.activeInHierarchy)
        {
            repeaterStandBy.SetActive(true);

        }else if(temp > 4 && AmazonBackgroung.activeInHierarchy)
        {
            buyRepeaterButton.SetActive(true);
        }
        else
        {
            repeaterStandBy.SetActive(false);
            buyRepeaterButton.SetActive(false);
        }

        DisconectedPc = Math.Max(temp- maxConected, 0);
        DisconectedPcText.text = DisconectedPc.ToString() + " disconected computers";

        pcNumText.text = temp.ToString();

        ConsumedEnergy = temp * cryptoPowerNecesity;

        if (IsEnergyPlanPlus)
        {
            EnergyPlusText.text = "-" + energyPricePerDay.ToString() + "$/Day\n-" + ConsumedEnergy.ToString() + "/" + energyPower.ToString() + "Units of energy.";
            EnergyBasicText.text = "-" + (energyPricePerDay-100).ToString() + "$/Day\n-" + ConsumedEnergy.ToString() + "/" + (energyPower-50).ToString() + "Units of energy.";
        }
        else
        {
            EnergyBasicText.text = "-" + energyPricePerDay.ToString() + "$/Day\n-" + ConsumedEnergy.ToString() + "/" + energyPower.ToString() + "Units of energy.";
            EnergyPlusText.text = "-" + (energyPricePerDay + 100).ToString() + "$/Day\n-" + ConsumedEnergy.ToString() + "/" + (energyPower + 50).ToString() + "Units of energy.";
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
        if (money < miningPCPrice || temp >= PCstorageRoom)
        {
            
            NotEnoughMoney.SetActive(true);

        }
        else
        {
            temp += 1;
            money -= miningPCPrice;
        }
    }

    public void buyRepeater()
    {
        if(money<repeaterPrice)
        {
            NotEnoughMoney.SetActive(true);
        }
        else
        {
            repeaterNum += 1;
            wifiCapacity += 4;
            money -= repeaterPrice;
            repeaterPrice = repeaterPrice;
        }
    }

    public void buyStorage()
    {
        if (money < 10000)
        {
            NotEnoughMoney.SetActive(true);
        }
        else
        {
            PCstorageRoom += 5;
            money -= 10000;
        }
    }

    public void upgradeEnergyPlan()
    {
        IsEnergyPlanPlus = true;
        energyPricePerDay += 100;
        energyPower += 50;
    }
    public void downgradeEnergyPlan()
    {
        IsEnergyPlanPlus = false;
        energyPricePerDay -= 100;
        energyPower -= 50;
    }
}
