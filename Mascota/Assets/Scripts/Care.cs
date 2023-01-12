using UnityEngine;
using System;

public class Care : MonoBehaviour
{
    public static Care instance;

    int timeToTouch = 2;
    DateTime timeTouching;
    bool alreadyTouch = false;

    public int timeToCare = 2;        //tiempo para conseguir puntos al acariciar
    public int timeToLosePoints = 30;  //tiempo para perder puntos por no ser acariciado
    public int timeWhitoutPet = 24;    //tiempo sin ser acariciado

    public string hourPetString;               //tiempo para conseguir puntos al acariciar
    public string lastTimeLosePointsPet;       //tiempo para perder puntos por no ser acariciado
    public string lastTimePetString;           //tiempo sin ser acariciado

    [SerializeField]
    GameObject particles, slime;

    private void Awake()
    {
        if (Care.instance == null)
        {
            Care.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lastTimeLosePointsPet = PlayerPrefs.GetString("lastTimeLosePointsPet", DateTime.Now.AddMinutes(timeToLosePoints).ToString());
        hourPetString = PlayerPrefs.GetString("hourPetString", DateTime.Now.AddSeconds(timeToCare).ToString());
        lastTimePetString = PlayerPrefs.GetString("lastTimePetString", DateTime.Now.AddHours(timeWhitoutPet).ToString());

        Animation.instance.CanPetText(CanPet());

        Debug.Log(lastTimeLosePointsPet + "lastTimeLosePointsPet");
        Debug.Log(hourPetString+"hourPetString");
        Debug.Log(lastTimePetString+"lastTimePetString");

        Debug.Log("canpet: "+CanPet());
        Debug.Log("canlosepoints: " + CanLosePoints());
        Debug.Log("nopet: " + NoPet());
    }

    // Update is called once per frame
    void Update()
    {
        if (NoPet() && CanLosePoints())
        {
            Debug.Log("if noPet && canLosePoints");
            Animation.instance.CanPetText(CanPet());
            LovePoints.instance.Points(-1);
            lastTimeLosePointsPet = DateTime.Now.ToString();
            PlayerPrefs.SetString("lastTimeLosePointsPet", lastTimeLosePointsPet);
            Debug.Log("save lastTimeLosePointsPet");
            PlayerPrefs.Save();
        }
        
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
                        alreadyTouch = true;
                    }

                    if (timeTouching < DateTime.Now)
                    {
                        if (CanPet())
                        {
                            Debug.Log("if canPet");
                            LovePoints.instance.Points(10);
                            hourPetString = DateTime.Now.AddHours(timeToCare).ToString();
                            lastTimePetString = DateTime.Now.AddHours(timeWhitoutPet).ToString();

                            PlayerPrefs.SetString("hourPetString", hourPetString);
                            PlayerPrefs.SetString("lastTimePetString", lastTimePetString);
                            PlayerPrefs.Save();

                            Debug.Log("save hourPetString");
                            Debug.Log("save lastTimePetString");

                            Animation.instance.CanPetText(CanPet());
                        }

                        Instantiate(particles, new Vector3(slime.transform.position.x, slime.transform.position.y + 1, slime.transform.position.z), Quaternion.identity);
                        alreadyTouch = false;
                    }
                }
            }
        }
    }

    public bool CanPet()
    {
        DateTime whenCanPet = DateTime.Parse(hourPetString);
        return whenCanPet < DateTime.Now;
    }

    public bool NoPet()
    {
        DateTime whenNoPet = DateTime.Parse(lastTimePetString);
        return whenNoPet < DateTime.Now;
    }

    public bool CanLosePoints()
    {
        DateTime lastTimeLosePoints = DateTime.Parse(lastTimeLosePointsPet);
        return lastTimeLosePoints.AddMinutes(timeToLosePoints) < DateTime.Now;
    }
}
