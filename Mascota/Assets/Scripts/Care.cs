using UnityEngine;
using System;

public class Care : MonoBehaviour
{
    int timeToTouch = 2;
    DateTime timeTouching;
    bool alreadyTouch = false;



    [SerializeField]
    GameObject particles, slime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButton(0)) || (Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Moved))
        {            
            Vector3 pos = Input.mousePosition;
            if (Application.platform == RuntimePlatform.Android)
            {
                pos = Input.GetTouch(0).position;
            }

            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.tag.Equals("Player"))
                {                    
                    Debug.Log("touching slime");



                    if (!alreadyTouch)
                    {
                        timeTouching = DateTime.Now.AddSeconds(timeToTouch);
                        Debug.Log("timetouching: " + timeTouching);
                        alreadyTouch = true;
                    }
                    
                    if (timeTouching < DateTime.Now)
                    {
                        LovePoints.instance.Points(10);
                        Instantiate(particles, new Vector3(slime.transform.position.x, slime.transform.position.y + 1, slime.transform.position.z), Quaternion.identity);
                        alreadyTouch = false;
                    }                  
                }
            }
        }
    }
}
