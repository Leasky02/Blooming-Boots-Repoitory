using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    //variables relating to collisions and movement
    public Collider2D groundSensor;
    public float jumpForce = 1000f;
    public int directionalForce = 130;
    public string groundTag = "Ground";
    public int hazardDamage;

    private bool touchingGround = false;

    //audio varibales containing sounds
    public AudioClip landingSound;
    public AudioClip chargeSound;
    public AudioClip releaseSound;

    //variables used in jumping and audio
    public int jumpDirection = 0;
    public float charge = 1;
    public bool justStarted = true;
    public bool chargeStarted = false;
    public bool attemptJump = false;

    //when collision first occurs, plays the sound of hitting ground
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(groundTag) == true && !justStarted)
        {
            AudioSource ourAudioSource = GetComponent<AudioSource>();
            ourAudioSource.clip = landingSound;
            ourAudioSource.Play();
            
        }
        justStarted = false;

    }

    //when left button held down

    public void LeftHeld()
    {

        if(charge <= 8f)
            charge += 0.08f;

        AudioSource ourAudioSource = GetComponent<AudioSource>();

        if(!ourAudioSource.isPlaying && !chargeStarted && !attemptJump)
        {
            if (touchingGround)
            {
                ourAudioSource.clip = chargeSound;
                ourAudioSource.Play();
                chargeStarted = true;
                gameObject.GetComponent<Animator>().Play("leftSquat");

                /*if(player < 50)
                {
                    //set back to left default animation
                    gameObject.GetComponent<Animator>().Play("DyingleftSquat");
                } else
                {
                    //set back to left default animation
                    gameObject.GetComponent<Animator>().Play("leftSquat");
                }*/
            }
        }
    }

    //when right button held down

    public void RightHeld()
    {
        if (charge <= 8f)
            charge += 0.08f;

        AudioSource ourAudioSource = GetComponent<AudioSource>();

        if (!ourAudioSource.isPlaying && !chargeStarted && !attemptJump)
        {
            if (touchingGround)
            {
                ourAudioSource.clip = chargeSound;
                ourAudioSource.Play();
                chargeStarted = true;
                gameObject.GetComponent<Animator>().Play("rightSquat");

                /*if(player < 50)
                {
                    //set back to left default animation
                    gameObject.GetComponent<Animator>().Play("DyingRightSquat");
                } else
                {
                    //set back to left default animation
                    gameObject.GetComponent<Animator>().Play("RightSquat");
                }*/
            }
        }
    }

    //when left button released

    public void LeftReleased()
    {
        attemptJump = true;
        jumpDirection = -1;

        chargeStarted = false;

        //get the playerHealth script attached to object if there is one
        PlayerHealth player = GetComponent<PlayerHealth>();
        //check if there is actually a player health script
        if (player != null)
        {
            //there is a player script on the object collided with so will then perform action
            player.ChangeHealth(-hazardDamage);
        }
        gameObject.GetComponent<Animator>().Play("leftTall");

        /*if(player < 50)
        {
            //set back to left default animation
            gameObject.GetComponent<Animator>().Play("DyingLeftTall");
        } else
        {
            //set back to left default animation
            gameObject.GetComponent<Animator>().Play("leftTall");
        }*/

    }

    //when right button released


    public void RightReleased()
    {
        attemptJump = true;
        jumpDirection = 1;
        //set back to right default animation

        chargeStarted = false;

        //get the playerHealth script attached to object if there is one
        PlayerHealth player = GetComponent<PlayerHealth>();
        //check if there is actually a player health script
        if (player != null)
        {
            //there is a player script on the object collided with so will then perform action
            player.ChangeHealth(-hazardDamage);
        }
        gameObject.GetComponent<Animator>().Play("rightTall");

        /*if(player < 50)
        {
            //set back to left default animation
            gameObject.GetComponent<Animator>().Play("DyingRightTall");
        } else
        {
            //set back to left default animation
            gameObject.GetComponent<Animator>().Play("RightTall");
        }*/
    }

    //constantly testing for player to jump

    public void FixedUpdate()
    {
        LayerMask mask = LayerMask.GetMask(groundTag);
        touchingGround = groundSensor.IsTouchingLayers(mask.value);

        if (touchingGround && attemptJump)
        {
            Rigidbody2D ourRigidbody = GetComponent<Rigidbody2D>();
            ourRigidbody.AddForce(Vector2.up * jumpForce * charge);
            Vector2 jumpDirectionVector = jumpDirection == 1 ? Vector2.right : Vector2.left;
            ourRigidbody.AddForce(jumpDirectionVector * directionalForce * charge * 4 / 5);
            charge = 1f;
            touchingGround = false;

            AudioSource ourAudioSource = GetComponent<AudioSource>();
            ourAudioSource.clip = releaseSound;
            ourAudioSource.Play();
        }
        attemptJump = false;
    }

}