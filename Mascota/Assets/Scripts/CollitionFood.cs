using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollitionFood : MonoBehaviour
{
    public static CollitionFood instance;

    public float sizeX;

    private void Awake()
    {
        if (CollitionFood.instance == null)
        {
            CollitionFood.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Food")
        {
            if (Hungry.instance.isHungry)
            {
                LovePoints.instance.Points(3);
                Hungry.instance.hungerPoints += 3;                
            }
            else
            {
                sizeX = transform.localScale.x;
                transform.localScale = new Vector3(sizeX + 0.1f, 2, 2);
            }

            col.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "Obstacle")
        {
            LovePoints.instance.Points(-1);
            col.gameObject.SetActive(false);
        }
    }
}
