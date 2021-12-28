using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    //GameManager gameManager;
    [SerializeField]GameObject explosion;
    [SerializeField] GameObject[] powerUpsPrefebs;
    [SerializeField] int powerUpChance = 20;
    [SerializeField] bool isQuitting;

    private void Start()
    {

        // = FindObjectOfType<GameManager>();
        if(GameManager.Instance != null)
        {
            GameManager.Instance.BricksOnLevel++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(GameManager.Instance != null)
        {
            GameManager.Instance.BricksOnLevel--;
            GameManager.Instance.UpdateScore(); //Comented 22-12-2021
        }
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

   
    void OnApplicationQuit()
    {   
        isQuitting = true;
    }


    private void OnDestroy()
    {
        if(isQuitting)
            return;
        
        if(GameManager.Instance.powerUpOnScene)
            return;
            
        int possibillity = Random.Range(0, 100);

        if(possibillity < powerUpChance)
        {
            int randomPowerUp = Random.Range(0, powerUpsPrefebs.Length);
            Instantiate(powerUpsPrefebs[randomPowerUp], transform.position, Quaternion.identity);
            GameManager.Instance.powerUpOnScene = true;
        }

    }

}
