using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// NOTE: Make sure your ground has the "Ground" tag (or whatever custom tag you set it to)
// NOTE: You may need to change your player's Rigidbody settings to Sleeping Mode: Never Sleep

public class PlayerJump : MonoBehaviour
{
    // An editor variable to control how much upward force the player gets when they jump
    // Larger numbers means higher jumps
    public float jumpForce = 1000f;

    // An editor variable to control what tag the script should look for when checking if you are touching the ground
    // Make sure the name matches the tag EXACTLY
    public string groundTag = "Ground";

    // A variable to keep track if we are touching the ground this frame
    private bool touchingGround = false;

    // A varibale to keep track if the player has requested a jump
    private bool attemptJump = false;

    // Function that should be called when the player tries to jump, from keyboard or on-screen buttons
    public void Jump()
    {
        // We record the attempt to jump, so we can process it in FixedUpdate with the other physics code
        attemptJump = true;

    }

    // This function is called by Unity at the begining of all of the physics code
    // At this point, in the last frame, we will have recorded whether we were touching the ground
    // and also whether we were trying to jump
    public void FixedUpdate()
    {
        // If we requested a jump in the last frame...
        if (attemptJump)
        {
            // ...and if we were also touching the ground in the last frame...
            if (touchingGround == true)
            {
                // ...we should jump!

                // First, get our physics rigidbody attached to this GameObject and store it so we can use it
                Rigidbody2D ourRigidbody = GetComponent<Rigidbody2D>();

                // Use our physics rigidbody to add an upward force
                // We multiply the upward force by the jumpForce variable we set in the editor
                // This makes us jump at a different height
                ourRigidbody.AddForce(Vector2.up * jumpForce);
            }

            // We have now processed this attempt to jump, so we should set it back to false.
            attemptJump = false;
        }

        // We are starting a new frame now, so we need to set our touchingGround to false.
        // It will be set to true again if we touch ground this frame.
        touchingGround = false;
    }

    // This function is called by Unity when our player collides with another object
    public void OnCollisionStay2D(Collision2D collision)
    {
        // We need to check if the thing we collided with (collision.collider) is actually ground
        // so we compare the tag on it with our "groundTag" variable ("Ground") by default
        if (collision.collider.CompareTag(groundTag) == true)
        {
            // If the thing we touched was actually the ground, then we should set our touchingGround flag to true
            // This means that if we request a jump this frame, then next frame the jump will actually be processed since we were touching the ground.
            touchingGround = true;
        }
    }
}