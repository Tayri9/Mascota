using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Feed : MonoBehaviour
{
    bool feed = false;
    float time = 30f;
    int i = 0;

    [SerializeField]
    GameObject[] prefabs = new GameObject[7];

    [SerializeField]
    GameObject slime;

    [SerializeField]
    TextMeshProUGUI timeText;

    float[] timeSpawn = {30f, 26f, 22f, 18f, 14f, 10f, 6f};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {           
        if(feed)
        {
            if (time >= 0 && LovePoints.instance.points > 0)
            {
                timeText.text = ((int)time).ToString();
                time -= Time.deltaTime;                
                if(i < timeSpawn.Length)
                {
                    if (timeSpawn[i] >= time)
                    {
                        Vector3 position = new Vector3(Random.Range(-3f, 3f), transform.position.y, transform.position.z);
                        Instantiate(prefabs[i], position, Quaternion.identity);
                        i++;
                    }
                }                
            }
            else
            {
                time = 30;
                i = 0;
                feed = false;
                Animation.instance.PantallaInicial();
                slime.transform.position = new Vector3(0, -2, 0);                            
            }
        }
    }

    public void StartFeed()
    {
        feed = true;
    }

    void TimeSpawn()
    {        
    }
}
