using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I personally prefer strafing movement to turning, but I've made both available.

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
        //TurningMovement(); // Uncheck Freeze Rotation Z.
        StrafingMovement(); // Check Freeze Rotation Z.
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
