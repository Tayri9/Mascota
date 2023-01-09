using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preferences : MonoBehaviour
{
    [SerializeField]
    GameObject slime;
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
        PlayerPrefs.SetString("isHungry", Hungry.instance.isHungry.ToString());
        PlayerPrefs.SetFloat("size", slime.transform.localScale.x);

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
