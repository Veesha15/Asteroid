using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    private int currentScore;
    [SerializeField] private TextMeshProUGUI currentScoreText;

    private void OnEnable()
    {
        AsteroidSplit.OnDestroyed += UpdateScore;
    }

    private void OnDisable()
    {
        AsteroidSplit.OnDestroyed -= UpdateScore;
    }

    private void UpdateScore(int _amount)
    {
        currentScore += _amount;
        currentScoreText.text = currentScore.ToString();
    }
}
