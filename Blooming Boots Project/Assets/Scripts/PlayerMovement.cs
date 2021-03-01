using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Public variables
    public float forceStrength;

    //Called by each button for movement

    public void MoveLeft()
    {
        //Get rigidbody that'll be used for movement
        Rigidbody2D ourRigidBody = GetComponent<Rigidbody2D>();

        //move in correct direction with the set force strength
        ourRigidBody.AddForce(Vector2.left * forceStrength);
    }
    public void MoveRight()
    {
        Rigidbody2D ourRigidBody = GetComponent<Rigidbody2D>();

        ourRigidBody.AddForce(Vector2.right * forceStrength);
    }
}
