using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            Paddle paddle = FindObjectOfType<Paddle>();
            if(paddle != null)
            {
                paddle.BulletsActive = true; 

                GameManager gameManager = FindObjectOfType<GameManager>();
                
                if(gameManager != null)
                {
                    gameManager.powerUpIsActive = true; 
                }
            }
        }
    }

    void OnDestroy()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if(gameManager != null)
            if(gameManager.powerUpOnScene)
            {
                gameManager.powerUpOnScene = false;
            }
    }
}
