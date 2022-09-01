using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Asteroids slow down and bunch. Change to velocity instead of impulse?
// TODO: Catch straggler
public class Asteroid : MonoBehaviour
{
    private Rigidbody2D myRigidBody2D;

    private int directionRadius = 5;
    private float randomForce;

    private float forceMin = 1;
    private float forceMax = 3;

    private void Awake()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        randomForce = Random.Range(forceMin, forceMax);
        Vector2 direction = ((Random.insideUnitCircle * directionRadius) - (Vector2)transform.position);
        myRigidBody2D.AddForce(direction.normalized * randomForce, ForceMode2D.Impulse);
    }
}
