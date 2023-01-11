using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollitionFood : MonoBehaviour
{   
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Food"))
        {
            if (Hungry.instance.IsHungry())
            {
                LovePoints.instance.Points(3);
                Hungry.instance.hungerPoints += 3;                
            }
            else
            {
                LovePoints.instance.sizeX = transform.localScale.x;
                transform.localScale = new Vector3(LovePoints.instance.sizeX + 0.1f, 2, 2);
                LovePoints.instance.sizeX = transform.localScale.x;
                PlayerPrefs.SetFloat("size", LovePoints.instance.sizeX);
                PlayerPrefs.Save();
                Debug.Log("save sizex");
            }

            col.gameObject.SetActive(false);
        }

        if (col.CompareTag("Obstacle"))
        {
            LovePoints.instance.Points(-1);
            col.gameObject.SetActive(false);
        }
    }
}
