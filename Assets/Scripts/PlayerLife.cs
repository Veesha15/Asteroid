using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private int lives = 3;

    public static event Action OnPlayerDeath;
    public static event Action<int> OnLifeLost;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerDeath();
        Destroy(collision.gameObject); // Destroy asteroid that hit player to give player time to get away.
    }


    private void PlayerDeath()
    {
        anim.Play("explosion-animation");

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
