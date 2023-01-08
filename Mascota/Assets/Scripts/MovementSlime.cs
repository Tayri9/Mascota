using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSlime : MonoBehaviour
{
    float speed = 50f;
    float speed1 = 2.5f;

    [SerializeField]
    KeyCode buttonRight, buttonLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(buttonRight))
        {
            transform.position += Vector3.right * Time.deltaTime * speed1;
        }

        if (Input.GetKey(buttonLeft))
        {
            transform.position += Vector3.left * Time.deltaTime * speed1;
        }
    }

    public void MoveRight()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;

    }

    public void MoveLeft()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;

    }
}
