using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI currentScoreText, highScoreText;
    [SerializeField] private GameObject[] currentLives;

    // Other screens are set active through button's OnClick Event in Inspector.

    private void OnEnable()
    {
        PlayerLife.OnPlayerDeath += DisplayGameOver;
        PlayerLife.OnLifeLost += DisplayCurrentLives;
        AsteroidDestruction.OnEarnedPoints += DisplayCurrentScore;
    }

    private void OnDisable()
    {
        PlayerLife.OnPlayerDeath -= DisplayGameOver;
        PlayerLife.OnLifeLost -= DisplayCurrentLives;
        AsteroidDestruction.OnEarnedPoints -= DisplayCurrentScore;
    }


    private void DisplayGameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }
    
    private void DisplayCurrentLives(int _lives)
    {
        currentLives[_lives].SetActive(false); // The current life integer corresponds to the array index.
    }

    private void DisplayCurrentScore(int _amount)
    {
        Score.currentScore += _amount;
        currentScoreText.text = Score.currentScore.ToString();
    }

    public void DisplayHighScores() // Assigned to Game Over button in Inspector.
    {
        Score.AssignHighScores();
        highScoreText.text = $"{Score.highScores[0]}\n{Score.highScores[1]}\n{Score.highScores[2]}";
    }

    public void StartGame() // Assigned to Main Menu button in Inspector.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        Score.currentScore = 0;
    }


}
