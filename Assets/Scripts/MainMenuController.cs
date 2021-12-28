using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip bottonPressedSfx;
    [SerializeField] GameObject loadGameButton;
    [SerializeField] AudioClip gameMusic;

    private void Start()
    {
        audioSource.clip = gameMusic;
        audioSource.Play();
    }


    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadSceneWithDelay(float delay)
    {
        loadGameButton.SetActive(false);
        audioSource.clip = bottonPressedSfx;
        audioSource.Play();
        Invoke("Play", delay);
    }

    public void PlaySfx()
    {
        audioSource.PlayOneShot(bottonPressedSfx);
    }

}


