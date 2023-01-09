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

    string lastTimeLosePointsHungry;
    string hourHungryString;

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
        DateTime whenIsHungry = DateTime.Now.AddSeconds(10);
        hourHungryString = whenIsHungry.ToString();
        lastTimeLosePointsHungry = DateTime.Now.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(hungerPoints == maxHungerPoints)
        {
            DateTime whenIsHungry = DateTime.Now.AddMinutes(3);
            hourHungryString = whenIsHungry.ToString();
            hungerPoints = 0;
            Animation.instance.IsHungry(IsHungry());
        }

        if(IsHungry() && CanLosePoints())
        {
            Animation.instance.IsHungry(IsHungry());
            LovePoints.instance.Points(-1);
            lastTimeLosePointsHungry = DateTime.Now.ToString();
        }
    }

    public bool CanLosePoints()
    {
        DateTime lastTimeLosePoints = DateTime.Parse(lastTimeLosePointsHungry);
        return lastTimeLosePoints.AddSeconds(20) < DateTime.Now;
    }

    public bool IsHungry()
    {
        DateTime whenIsHungry = DateTime.Parse(hourHungryString);
        return whenIsHungry < DateTime.Now;
    }
}
