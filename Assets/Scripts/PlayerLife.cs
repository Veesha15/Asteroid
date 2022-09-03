using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private int lives = 3;

    private void OnEnable()
    {
        AsteroidSplit.OnPlayerContact += PlayerDeath;
    }

    private void OnDisable()
    {
        AsteroidSplit.OnPlayerContact -= PlayerDeath;
    }


    private void PlayerDeath()
    {
        if (lives == 0)
        {
            print("game over");
        }
        else
        {
            lives--;
            print(lives);
        }

    }
}
