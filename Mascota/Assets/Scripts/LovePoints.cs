using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LovePoints : MonoBehaviour
{
    public static LovePoints instance;

    [SerializeField]
    public int points;

    public float sizeX;

    int level, startPoints = 1;

    float startSizeX = 2;

    [SerializeField]
    TextMeshProUGUI pointsText, levelText;

    [SerializeField]
    GameObject slime, babySlime, juniorSlime, seniorSlime, queenSlime;

    string[] slimeLevel = { "Dead", "Baby", "Junior", "Senior", "Queen" };


    private void Awake()
    {
        if (LovePoints.instance == null)
        {
            LovePoints.instance = this;

        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {       
        points = PlayerPrefs.GetInt("lovePoints", startPoints);
        sizeX = PlayerPrefs.GetFloat("size", startSizeX);
        CheckSlime();
        Debug.Log("puntos: " + points);
        Debug.Log("level: " + level);

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Points(int amount)
    {
        points += amount;
        PlayerPrefs.SetInt("lovePoints", points);
        PlayerPrefs.Save();
        Debug.Log("save points");
        CheckSlime();
    }

    public void CheckSlime()
    {
        SetLevel(points);
        pointsText.text = points.ToString();
        levelText.text = slimeLevel[level];
        slime.transform.localScale = new Vector3(sizeX, 2, 2);
        SetSlime();
    }

    public void NewGame()
    {
        points = startPoints;
        sizeX = startSizeX;
        Hungry.instance.hungerPoints = 0;
        CheckSlime();

        PlayerPrefs.SetInt("lovePoints", points);
        PlayerPrefs.SetFloat("size", sizeX);
        PlayerPrefs.SetString("hourHungryString", DateTime.Now.AddSeconds(Hungry.instance.timeToHungry).ToString());
        PlayerPrefs.SetString("lastTimeLosePointsHungry", DateTime.Now.AddSeconds(Hungry.instance.timeToLosePoints).ToString());

        PlayerPrefs.SetString("lastTimeLosePointsPet", DateTime.Now.ToString());
        PlayerPrefs.SetString("hourPetString", DateTime.Now.ToString());
        PlayerPrefs.SetString("lastTimePetString", DateTime.Now.ToString());
        /*
        PlayerPrefs.SetString("lastTimeLosePointsPet", DateTime.Now.AddMinutes(Care.instance.timeToLosePoints).ToString());
        PlayerPrefs.SetString("hourPetString", DateTime.Now.AddSeconds(Care.instance.timeToCare).ToString());
        PlayerPrefs.SetString("lastTimePetString", DateTime.Now.AddHours(Care.instance.timeWhitoutPet).ToString());
        */
        PlayerPrefs.Save();
        
    }

    void SetLevel(int points)
    {

        if (points < 1)
        {
            level = 0;
            Animation.instance.GameOver();            
        }
        else if (points >= 1 && points <= 5)
        {
            level = 1;
        }
        else if (points >= 6 && points <= 20)
        {
            level = 2;
        }
        else if (points >= 21 && points <= 60)
        {
            level = 3;
        }
        else if (points >= 61)
        {
            level = 4;
        }
    }

    void SetSlime()
    {
        switch (level)
        {
            case 0:
                babySlime.SetActive(false);
                juniorSlime.SetActive(false);
                seniorSlime.SetActive(false);
                queenSlime.SetActive(false);
                Debug.Log("case 0");
                break;

            case 1:
                babySlime.SetActive(true);
                juniorSlime.SetActive(false);
                seniorSlime.SetActive(false);
                queenSlime.SetActive(false);
                Debug.Log("case 1");
                break;

            case 2:
                babySlime.SetActive(false);
                juniorSlime.SetActive(true);
                seniorSlime.SetActive(false);
                queenSlime.SetActive(false);
                Debug.Log("case 2");
                break;

            case 3:
                babySlime.SetActive(false);
                juniorSlime.SetActive(false);
                seniorSlime.SetActive(true);
                queenSlime.SetActive(false);
                Debug.Log("case 3");
                break;

            case 4:
                babySlime.SetActive(false);
                juniorSlime.SetActive(false);
                seniorSlime.SetActive(false);
                queenSlime.SetActive(true);
                Debug.Log("case 4");
                break;
        }
    }
}
