using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRigidBody2D;
    private float speed = 8;


    private void Awake()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // TODO: should Input be in Update | new keyword in update loop?
        myRigidBody2D.MovePosition(myRigidBody2D.position + speed * Time.fixedDeltaTime * direction);
    }


}
