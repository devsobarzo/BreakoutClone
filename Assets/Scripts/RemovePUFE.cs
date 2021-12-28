using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePUFE : MonoBehaviour
{
    [SerializeField] bool isQuitting;
    //GameManager gameManager;

    private void Start()
    {
        //gameManager = FindObjectOfType<GameManager>();
    }
    
    
    void OnApplicationQuit()
    {   
        isQuitting = true;
    }

    private void OnDestroy()
    {
        if(isQuitting)
            return;

        if(GameManager.Instance != null)
            if(GameManager.Instance.powerUpOnScene)
            {
                GameManager.Instance.powerUpOnScene = false;
            }
    }
}
