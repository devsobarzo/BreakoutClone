using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField]Rigidbody2D rigidbody2D;
    [SerializeField]AudioController audioControlller;
    [SerializeField]AudioClip bounceSfx;
    Vector2 moveDirection;
    Vector2 currentVelocity;
    public float ballSpeed = 5;
    GameManager gameManager;
    Transform paddle;
    private float AVelocity = 1.1f;
    bool superBall;
    [SerializeField] float superBallTime = 10;

    public bool SuperBall{
        get => superBall;
        set{
            superBall = value;
            if(superBall)
                StartCoroutine(ResetSuperBall());
        }
    }

    // Start is called before the first frame update
    void Start()
    {   
        gameManager = FindObjectOfType<GameManager>();
        paddle = transform.parent; 
    }

    private void Update()
    {
        InstantiateBall();    
    }

    void FixedUpdate()
    {
        currentVelocity = rigidbody2D.velocity;  
    }

    void InstantiateBall()
    {
        if(Input.GetKey(KeyCode.Space) && (!gameManager.ballIsOnPlay))
        {         
            float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
            float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
            
            rigidbody2D.velocity = new Vector2(xVelocity, yVelocity) * ballSpeed;
            transform.parent = null;
            gameManager.ballIsOnPlay = true;

            if(!gameManager.GameStarted)
            {
                gameManager.GameStarted = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Brick") && superBall)
        {
            rigidbody2D.velocity = currentVelocity;
            return;
        }

        moveDirection = Vector2.Reflect(currentVelocity, collision.GetContact(0).normal);
        rigidbody2D.velocity = moveDirection;
        audioControlller.PlaySfx(bounceSfx);
        
        if(collision.transform.CompareTag("BotomLimit"))
        {
            if(gameManager != null)
            {
                gameManager.PlayerLives--;
                if(gameManager.PlayerLives > 0)
                {
                    rigidbody2D.velocity = Vector2.zero;
                    transform.parent = null;
                    transform.SetParent(paddle);
                    transform.localPosition = new Vector2(0, 0.45f);    
                    gameManager.ballIsOnPlay = false;
                }
                
            }

        }
    }

    IEnumerator ResetSuperBall()
    {
        yield return new WaitForSeconds(superBallTime);
        gameManager.powerUpIsActive = false;
        superBall = false;
    }
}
