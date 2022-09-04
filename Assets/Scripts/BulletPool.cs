using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletContainer;
    
    public Queue<GameObject> bulletPool = new Queue<GameObject>();
    private int bulletAmount = 15;

    private void OnEnable()
    {
        ScreenBounds.OnBulletOutOfBounds += RecycleBullet;
        Bullet.OnBulletHitSomething += RecycleBullet;
    }

    private void OnDisable()
    {
        ScreenBounds.OnBulletOutOfBounds -= RecycleBullet;
        Bullet.OnBulletHitSomething -= RecycleBullet;
    }

    private void Start()
    {
        SpawnInitialBullets();
    }

    private void SpawnInitialBullets()
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            GameObject tempBullet = Instantiate(bulletPrefab, bulletContainer);
            tempBullet.SetActive(false);
            bulletPool.Enqueue(tempBullet);
        }
    }

    private void RecycleBullet(GameObject _bullet)
    {
        bulletPool.Enqueue(_bullet);
        _bullet.SetActive(false);
    }


}
