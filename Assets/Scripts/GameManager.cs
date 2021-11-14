using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int bricksOnLevel;
    Ball ball;
    public int score;
    public Text scoreText;
    public bool ballIsOnPlay;

    public int BricksOnLevel {
        get =>bricksOnLevel;
        set {
            bricksOnLevel = value;
            if(bricksOnLevel == 0)
            {
                print("You Win!!");
                Destroy(GameObject.Find("Ball"));
            }

        }
    }

    public void UpdateScore()
    {
        score += 100;
        scoreText.text = "Score: " +score;
    }



}
