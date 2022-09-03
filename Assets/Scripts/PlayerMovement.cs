using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRigidBody2D;

    private float yInput;
    private float xInput;

    private float moveSpeed = 8;
    private float turnSpeed = 150;

    private void Awake()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        yInput = Input.GetAxis("Vertical");
        xInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        //TurningMovement(); // uncheck Freeze Rotation Z
        StrafingMovement();
    }

    private void StrafingMovement()
    {
        Vector2 direction = new Vector2(xInput, yInput);
        myRigidBody2D.velocity = direction * moveSpeed;
    }

    private void TurningMovement() 
    {
        myRigidBody2D.velocity = moveSpeed * yInput * transform.up;
        myRigidBody2D.angularVelocity = -xInput * turnSpeed;
    }


}
