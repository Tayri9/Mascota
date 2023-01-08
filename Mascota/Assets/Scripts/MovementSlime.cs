using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSlime : MonoBehaviour
{
    float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveRight()
    {
        gameObject.transform.Translate(1 * speed * Time.deltaTime, 0, 0);
    }

    public void MoveLeft()
    {
        gameObject.transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
    }
}
