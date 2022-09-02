using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletContainer;

    private Queue<GameObject> bulletPool = new Queue<GameObject>();
    private int bulletAmount = 15;

    private void OnEnable()
    {
        ScreenBounds.OnBulletOutOfBounds += RecycleBullet;
        AsteroidSplit.OnBulletContact += RecycleBullet;
    }

    private void OnDisable()
    {
        ScreenBounds.OnBulletOutOfBounds -= RecycleBullet;
        AsteroidSplit.OnBulletContact += RecycleBullet;
    }

    private void Start()
    {
        InstantiateBullets();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ShootBullet();
        }
    }

    private void InstantiateBullets()
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            GameObject tempBullet = Instantiate(bulletPrefab, bulletContainer);
            tempBullet.SetActive(false);
            bulletPool.Enqueue(tempBullet);
        }
    }

    private void ShootBullet()
    {
        GameObject bulletToShoot = bulletPool.Dequeue();
        bulletToShoot.transform.position = bulletContainer.transform.position; // TODO: better performance to cache 
        bulletToShoot.SetActive(true);
    }

    private void RecycleBullet(GameObject _bullet)
    {
        bulletPool.Enqueue(_bullet);
        _bullet.SetActive(false);
    }
}
