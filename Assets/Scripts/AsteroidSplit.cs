using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// TODO: instantiate as child of parent container
// TODO static class for spawn points
// TODO: detroy astroid that kills player
public class AsteroidSplit : MonoBehaviour
{
    [SerializeField] GameObject splitInto;
    [SerializeField] private SplitType splitToPerform;
    [SerializeField] private int pointsToEarn;

    private enum SplitType
    {
        TwoChunks,
        ThreeChunks,
        NewChunk
    }

    public static event Action<GameObject> OnBulletContact;
    public static event Action OnPlayerContact;
    public static event Action<int> OnDestroyed;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            OnBulletContact?.Invoke(collision.gameObject);
            OnDestroyed?.Invoke(pointsToEarn);

            switch (splitToPerform)
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

        if (collision.gameObject.layer == 7)
        {
            OnPlayerContact?.Invoke();
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
