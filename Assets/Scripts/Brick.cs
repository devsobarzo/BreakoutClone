using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField]GameObject explosion;
    [SerializeField] GameObject[] powerUpsPrefebs;
    [SerializeField] int powerUpChance = 20;

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
        if(gameManager != null)
        {
            gameManager.BricksOnLevel--;
            gameManager.UpdateScore(); //Comented 22-12-2021
        }
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    
    private void OnDestroy()
    {
        if(gameManager.powerUpOnScene)
            return;
            
        int possibillity = Random.Range(0, 100);

        if(possibillity < powerUpChance)
        {
            int randomPowerUp = Random.Range(0, powerUpsPrefebs.Length);
            Instantiate(powerUpsPrefebs[randomPowerUp], transform.position, Quaternion.identity);
            gameManager.powerUpOnScene = true;
        }

    }

}
