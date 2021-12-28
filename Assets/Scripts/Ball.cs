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
    //GameManager gameManager;
    Transform paddle;
    private float AVelocity = 1.1f;
    bool superBall;
    [SerializeField] float superBallTime = 10;
  //  [SerializeField]float yMinSpeed = 2;
    [SerializeField]TrailRenderer trailRenderer; 


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
        GameManager.Instance = FindObjectOfType<GameManager>();
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
        if(Input.GetKey(KeyCode.Space) && (!GameManager.Instance.ballIsOnPlay))
        {         
            float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
            float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
            
            rigidbody2D.velocity = new Vector2(xVelocity, yVelocity) * ballSpeed;
            transform.parent = null;
            GameManager.Instance.ballIsOnPlay = true;

            if(!GameManager.Instance.GameStarted)
            {
                GameManager.Instance.GameStarted = true;
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
       /* if(Mathf.Abs(moveDirection.y) < yMinSpeed)
        {
            moveDirection.y = yMinSpeed * Mathf.Sign(moveDirection.y);
        }*/
        rigidbody2D.velocity = moveDirection;
        audioControlller.PlaySfx(bounceSfx);
        
        if(collision.transform.CompareTag("BotomLimit"))
        {
            if(GameManager.Instance != null)
            {
                GameManager.Instance.PlayerLives--;
                if(GameManager.Instance.PlayerLives > 0)
                {
                    rigidbody2D.velocity = Vector2.zero;
                    transform.parent = null;
                    transform.SetParent(paddle);
                    transform.localPosition = new Vector2(0, 0.45f);    
                    GameManager.Instance.ballIsOnPlay = false;
                }
                
            }

        }
    }

    IEnumerator ResetSuperBall()
    {
        trailRenderer.enabled = true;
        yield return new WaitForSeconds(superBallTime);
        trailRenderer.enabled = false;
        GameManager.Instance.powerUpIsActive = false;
        superBall = false;
    }
}
