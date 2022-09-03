using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuScreen, highScoresScreen, gameOverScreen;

    private void OnEnable()
    {
        PlayerLife.OnPlayerDeath += GameOver;
    }

    private void OnDisable()
    {
        PlayerLife.OnPlayerDeath -= GameOver;
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void ShowHighScores() // assigned to Game Over Continue to button in Inspector 
    {

    }

}
