using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Transform bulletPoint;
    [SerializeField] BulletPool pool;
 

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        GameObject bulletToShoot = pool.bulletPool.Dequeue();
        bulletToShoot.transform.position = bulletPoint.transform.position;
        bulletToShoot.transform.rotation = bulletPoint.transform.rotation;
        bulletToShoot.SetActive(true);
    }


}
