using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D myRigidBody2D;
    private float speed = 5;

    public static event Action<GameObject> OnHitSomething;


    private void Awake()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        myRigidBody2D.velocity = transform.up *  speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnHitSomething?.Invoke(collision.gameObject);
    }


}
