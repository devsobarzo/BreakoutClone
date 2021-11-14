using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField]GameObject explosion;

    private void Start()
    {

        gameManager = FindObjectOfType<GameManager>();

        if(gameManager != null)
        {
            gameManager.BricksOnLevel++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.BricksOnLevel--;
        gameManager.UpdateScore();
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
