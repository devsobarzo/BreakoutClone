using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBall : MonoBehaviour
{
//    [SerializeField] float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //  transform.Translate(Vector2.down * Time.deltaTime * speed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            Ball ball = FindObjectOfType<Ball>();
            if(ball != null)
            {
                ball.SuperBall = true;
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
    }
*/
}
