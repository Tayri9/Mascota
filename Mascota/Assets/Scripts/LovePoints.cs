using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LovePoints : MonoBehaviour
{
    public static LovePoints instance;

    int points, level;

    [SerializeField]
    TextMeshProUGUI pointsText, levelText;

    [SerializeField]
    GameObject babySlime, juniorSlime, seniorSlime, queenSlime;

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
        points = PlayerPrefs.GetInt("lovePoints", 1);
        SetLevel(points);
        pointsText.text = points.ToString();
        levelText.text = slimeLevel[level];
        SetSlime();
    }

    void  SetLevel(int points)
    {       

        if (points < 1)
        {
            level = 0;
        }
        else if(points >= 1 && points <= 5)
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
