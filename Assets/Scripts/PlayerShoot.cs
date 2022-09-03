using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: split pool into separate script
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Transform bulletPoint; // TODO: needs to be outside of player collider or otherwise set to ignore layer
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
