using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int bricksOnLevel;
    [SerializeField]int playerLives = 3;

    Ball ball;
    public int score;
    public Text scoreText;
    public bool ballIsOnPlay;
    float gameTime;
    bool gameStarted;

    public int BricksOnLevel {
        get =>bricksOnLevel;
        set {
            bricksOnLevel = value;
            if(bricksOnLevel == 0)
            {
                Destroy(GameObject.Find("Ball"));
                gameTime = Time.time - gameTime;
                print(gameTime);
                print("You Win!!");
            }
        }
    }

    public int PlayerLives {
        get => playerLives;
        set{
            playerLives = value;
            if(playerLives == 0)
            {
                Destroy(GameObject.Find("Ball"));
                Debug.Log("Game Over");
            }
        }
    }

    public bool GameStarted{
        get => gameStarted;
        set{
            gameStarted = value;
            gameTime = Time.time;
        }
    } 

    public void UpdateScore()
    {
        score += 100;
        scoreText.text = "Score: " +score;
    }


}
