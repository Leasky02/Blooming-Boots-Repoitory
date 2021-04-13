using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    //amount of damage the object does
    public int hazardDamage;
    //unity function that handles collisions
    //and is called when object collides with hazard object
    void OnCollisionEnter2D(Collision2D collisionData)
    {
        //get object we collided with
        Collider2D objectWeCollidedWith = collisionData.collider;

        //get the playerHealth script attached to object if there is one
        PlayerHealth player = objectWeCollidedWith.GetComponent<PlayerHealth>();
        //check if there is actually a player health script
        if(player != null)
        {
            //there is a player script on the object collided with so will then perform action
            player.ChangeHealth(-hazardDamage);
        }
    }
}
