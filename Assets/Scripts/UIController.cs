using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField]GameObject loseScreen;
    [SerializeField]GameObject winnerScreen;
    [SerializeField]GameObject[] hearts;
    [SerializeField] Text timeText;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip bottonPressedSfx;

    [SerializeField] GameObject buttonTryAgain;
    [SerializeField] GameObject buttonMainMenu;



    public void ActivateLoseScreen()
    {
        loseScreen.SetActive(true);
    }

    public void ActivateWinnerScreen()
    {
        winnerScreen.SetActive(true);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateLives(int currentLives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i >= currentLives)
            {
                hearts[i].SetActive(false);
            }
        }
    }

    public void UpdateTime(float gameTime)
    {
        timeText.text = "Time: " + Mathf.Floor(gameTime);
    }

    public void LoadTryAgain(float delayTA)
    {
        audioSource.clip = bottonPressedSfx;
        audioSource.Play();
        Invoke("TryAgain", delayTA);
    }


    public void LoadMenu(float delayM)
    {
        audioSource.clip = bottonPressedSfx;
        audioSource.Play();
        Invoke("Menu", delayM);
    }


    public void PlaySfx()
    {
        audioSource.PlayOneShot(bottonPressedSfx);
    }


}
