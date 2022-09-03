using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private int lives = 3;

    public static event Action OnPlayerDeath;
    public static event Action<int> OnLifeLost;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerDeath();
    }


    private void PlayerDeath()
    {
        if (lives == 0)
        {
            OnPlayerDeath?.Invoke();
        }
        else
        {
            lives--;
            OnLifeLost?.Invoke(lives);
        }

    }


}
