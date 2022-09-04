using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D myRigidBody2D;
    private float speed = 5;

    public static event Action<GameObject> OnBulletHitSomething;


    private void Awake()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        myRigidBody2D.velocity = transform.up *  speed; // Bullet rotates with player when using TurnMovement.
    }

    private void OnCollisionEnter2D(Collision2D collision) // Bullet is set to ignore Player layer.
    {
        OnBulletHitSomething?.Invoke(gameObject);
    }


}
