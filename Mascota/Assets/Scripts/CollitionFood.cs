using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollitionFood : MonoBehaviour
{
    float sizeX;


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Food")
        {
            if (Hungry.instance.isHungry)
            {
                LovePoints.instance.Points(3);
                Hungry.instance.hungerPoints += 3;
                col.gameObject.SetActive(false);
            }
            else
            {
                sizeX = transform.localScale.x;
                transform.localScale = new Vector3(sizeX + 0.1f, 2, 2);
            }
            
        }

        if (col.gameObject.tag == "Obstacle")
        {
            LovePoints.instance.Points(-1);
            col.gameObject.SetActive(false);
        }
    }
}
