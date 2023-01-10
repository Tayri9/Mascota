using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preferences : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        PlayerPrefs.SetInt("lovePoints", LovePoints.instance.points);
        PlayerPrefs.SetFloat("size", CollitionFood.instance.sizeX + 0.1f);
        PlayerPrefs.SetString("hourHungryString", Hungry.instance.hourHungryString);
        PlayerPrefs.SetString("lastTimeLosePointsHungry", Hungry.instance.lastTimeLosePointsHungry);

        PlayerPrefs.Save();
        Debug.Log("save");
    }

    public void Delete()
    {
        PlayerPrefs.DeleteAll();
    }

    private void OnDestroy()
    {
        Save();
    }
}
