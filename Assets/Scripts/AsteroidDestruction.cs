using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidDestruction : MonoBehaviour
{
    [SerializeField] GameObject splitInto;
    [SerializeField] private SplitType splitType;
    [SerializeField] private int points;

    private enum SplitType
    {
        TwoChunks,
        ThreeChunks,
        NewChunk
    }

    public static event Action<int> OnEarnedPoints;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) // Bullet layer.
        {           
            OnEarnedPoints?.Invoke(points);
            DestroyAsteroid();
        }  
    }


    private void DestroyAsteroid()
    {
        switch (splitType)
        {
            case SplitType.TwoChunks:
                SplitIntoChunks(2, this.transform.position);
                break;

            case SplitType.ThreeChunks:
                SplitIntoChunks(3, this.transform.position);
                break;

            case SplitType.NewChunk:
                SplitIntoChunks(1, Random.insideUnitCircle * 20);
                break;
        }
    }

    private void SplitIntoChunks(int _amount, Vector2 _position)
    {
        for (int i = 0; i < _amount; i++)
        {
            Instantiate(splitInto, _position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


}
