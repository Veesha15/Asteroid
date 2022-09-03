using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// Screens set active through OnClick Event in Inspector
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuScreen, highScoresScreen, gameOverScreen;
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private GameObject[] currentLives;

    private void OnEnable()
    {
        PlayerLife.OnPlayerDeath += GameOver;
        PlayerLife.OnLifeLost += UpdateLives;
        AsteroidSplit.OnDestroyed += UpdateScore;
    }

    private void OnDisable()
    {
        PlayerLife.OnPlayerDeath -= GameOver;
        PlayerLife.OnLifeLost -= UpdateLives;
        AsteroidSplit.OnDestroyed -= UpdateScore;
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
        Score.currentScore = 0;
    }

    public void ShowHighScores() // assigned to Game Over Continue to button in Inspector 
    {
        Score.AssignHighScores();
        highScoreText.text = $"{Score.highScores[0]}\n{Score.highScores[1]}\n{Score.highScores[2]}";
    }

    private void UpdateScore(int _amount)
    {
        Score.currentScore += _amount;
        currentScoreText.text = Score.currentScore.ToString();
    }

    // the current life int corresponds to array index
    private void UpdateLives(int _lives)
    {
        currentLives[_lives].SetActive(false);
    }

}
