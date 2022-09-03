using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: split pool into separate script
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletContainer;
    [SerializeField] Transform bulletPoint; // TODO: needs to be outside of player collider or otherwise set to ignore layer

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
        bulletToShoot.transform.position = bulletPoint.transform.position;
        bulletToShoot.transform.rotation = bulletPoint.transform.rotation;
        bulletToShoot.SetActive(true);
    }

    private void RecycleBullet(GameObject _bullet)
    {
        bulletPool.Enqueue(_bullet);
        _bullet.SetActive(false);
    }
}
