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
        //PlayerPrefs.SetString("isHungry", Hungry.instance.isHungry.ToString());
        PlayerPrefs.SetFloat("size", CollitionFood.instance.sizeX);

        //lastTimeLosePointsHungry

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
