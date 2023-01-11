using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hungry : MonoBehaviour
{
    public static Hungry instance;

    //public bool isHungry = false;

    public int hungerPoints = 0;   

    int maxHungerPoints = 12;

    public string lastTimeLosePointsHungry;
    public string hourHungryString;

    //seconds
    public int timeToHungry = 60;
    public int timeToLosePoints = 10;

    private void Awake()
    {
        if (Hungry.instance == null)
        {
            Hungry.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        hourHungryString = PlayerPrefs.GetString("hourHungryString", DateTime.Now.AddSeconds(timeToHungry).ToString());        

        lastTimeLosePointsHungry = PlayerPrefs.GetString("lastTimeLosePointsHungry", DateTime.Now.AddSeconds(timeToLosePoints).ToString());

        Debug.Log(hourHungryString);
        Debug.Log(lastTimeLosePointsHungry);
    }

    // Update is called once per frame
    void Update()
    {
        if(hungerPoints == maxHungerPoints)
        {
            DateTime whenIsHungry = DateTime.Now.AddSeconds(timeToHungry);
            hourHungryString = whenIsHungry.ToString();
            PlayerPrefs.SetString("hourHungryString", hourHungryString);
            PlayerPrefs.Save();
            Debug.Log("save hourHungryString");
            hungerPoints = 0;
            Animation.instance.IsHungry(IsHungry());
        }

        if(IsHungry() && CanLosePoints())
        {
            Animation.instance.IsHungry(IsHungry());
            LovePoints.instance.Points(-1);
            lastTimeLosePointsHungry = DateTime.Now.ToString();
            PlayerPrefs.SetString("lastTimeLosePointsHungry", lastTimeLosePointsHungry);
            PlayerPrefs.Save();
            Debug.Log("save lastTimeLosePointsHungry");
        }
    }

    public bool IsHungry()
    {
        DateTime whenIsHungry = DateTime.Parse(hourHungryString);
        return whenIsHungry < DateTime.Now;
    }

    public bool CanLosePoints()
    {
        DateTime lastTimeLosePoints = DateTime.Parse(lastTimeLosePointsHungry);
        return lastTimeLosePoints.AddSeconds(timeToLosePoints) < DateTime.Now;
    }    

    void LostPoints()
    {
        if (IsHungry())
        {
            DateTime lastTimeLosePoints = DateTime.Parse(lastTimeLosePointsHungry);
            DateTime timeNow = DateTime.Now;

            int year = timeNow.Year;

            
        }
    }
}
