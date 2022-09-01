using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D myRigidBody2D;
    private GameObject target;
    private int speed = 7;

    public float stoppingDistance = 0.1f;

    private void Awake()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player"); // TODO: change how to get this reference
    }

    void FixedUpdate()
    {
        Vector3 direction = (target.transform.position - transform.position);

        if (direction.magnitude > stoppingDistance)
        {
            myRigidBody2D.MovePosition(transform.position + speed * Time.fixedDeltaTime * direction.normalized);
        }
    }
}
