using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
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

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
