using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AsteroidSpawner asteroidSpawner;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private TMP_Text gameOverText;

    public void EndGame()
    {
        asteroidSpawner.enabled = false;
        gameOverDisplay.gameObject.SetActive(true);
        int finalScore = scoreSystem.EndTimer();
        gameOverText.text = $"Your score: {finalScore}";
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void ContinueButton()
    {
        AdManager.Instance.ShowAd(this);
        continueButton.interactable = false;
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ContinueGame()
    {
        scoreSystem.StartTimer();
        player.transform.position = Vector3.zero;
        player.SetActive(true);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        asteroidSpawner.enabled = true;
        gameOverDisplay.gameObject.SetActive(false);
    }
}
