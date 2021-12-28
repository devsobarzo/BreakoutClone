using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSizePaddle : MonoBehaviour
{
    //[SerializeField] float speed = 5;

    private void Update()
    {
       // transform.Translate(Vector2.down * Time.deltaTime * speed);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            //collision.transform.GetComponent<Paddle>().IncreaseSize();
            Paddle paddle = collision.transform.GetComponent<Paddle>();
            if(paddle != null)
            {
                paddle.IncreaseSize();
            }

           // GameManager gameManager = FindObjectOfType<GameManager>();
            
            if(GameManager.Instance != null)
            {
               GameManager.Instance.powerUpIsActive = true; 
            }

            Destroy(gameObject);
        }
    }
/*
    void OnDestroy()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if(gameManager != null)
            if(gameManager.powerUpOnScene)
            {
                gameManager.powerUpOnScene = false;
            }
    }*/
}
