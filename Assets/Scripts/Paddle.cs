using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float paddleSpeed = 5;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -4, 0);
 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
      
        MoveLimits();
    }

    void Move()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        transform.position += Vector3.right * movement * Time.deltaTime * paddleSpeed;
    }

    void MoveLimits()
    {
        if(transform.position.x > 7.44f)
        {
            transform.position = new Vector3(7.44f, transform.position.y, 0);
        }
        else if(transform.position.x < -7.44f)
        {
            transform.position = new Vector3(-7.44f, transform.position.y, 0);
        }

    }

}
