using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D myRigidBody2D;
    private GameObject target;
    private float randomForce;

    private float forceMin = 1;
    private float forceMax = 8;

    private void Awake()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player"); // TODO: change how to get this reference
    }

    private void Start()
    {
        randomForce = Random.Range(forceMin, forceMax);
        Vector3 moveDirection = (target.transform.position - transform.position).normalized;
        myRigidBody2D.AddForce(moveDirection * randomForce, ForceMode2D.Impulse);
    }
}
