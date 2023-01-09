using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hungry : MonoBehaviour
{
    public static Hungry instance;

    public bool isHungry = false;

    public int hungerPoints = 0;

    int maxHungerPoints = 12;

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
        isHungry = bool.Parse(PlayerPrefs.GetString("isHungry", "false"));
    }

    // Update is called once per frame
    void Update()
    {
        if(hungerPoints == maxHungerPoints)
        {
            isHungry = false;
            hungerPoints = 0;
            Animation.instance.IsHungry(isHungry);
        }
    }
}
