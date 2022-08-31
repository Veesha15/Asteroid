using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    
    private float moveDirection;
    private float turnDirection;
    
    private float moveSpeed = 8;
    private float turnSpeed = 5;


    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveDirection = Input.GetAxis("Vertical");
        turnDirection = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        myRigidbody.velocity = transform.up * moveDirection * moveSpeed;
        myRigidbody.rotation += (-turnDirection * turnSpeed); 
    }


}
