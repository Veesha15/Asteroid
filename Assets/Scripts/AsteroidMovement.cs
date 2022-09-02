using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidMovement : MonoBehaviour
{
    private Rigidbody2D myRigidBody2D;

    private Vector2 randomDirection;
    private float speed;
    private float directionRadius = 5f;


    private void Awake()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        randomDirection = ((Random.insideUnitCircle * directionRadius) - (Vector2)transform.position);
        speed = Random.Range(0.5f, 1.5f);
    }

    private void FixedUpdate()
    {
        myRigidBody2D.velocity = randomDirection.normalized * speed;
    }


}
