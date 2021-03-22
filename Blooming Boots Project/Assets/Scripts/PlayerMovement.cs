﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    public float jumpForce = 1000f;
    public int directionalForce = 130;
    public string groundTag = "Ground";
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

        if (collision.collider.CompareTag(groundTag) == true)
        {
            touchingGround = true;
        }
    }

    //when collision ends, play sound of leaving ground

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(groundTag) != true)
        {
            touchingGround = false;
        }
    }

    //when left button held down

    public void LeftHeld()
    {
        if(charge <= 8f)
            charge += 0.08f;

        AudioSource ourAudioSource = GetComponent<AudioSource>();

        if(!ourAudioSource.isPlaying && !chargeStarted)
        {
            if (touchingGround)
            {
                ourAudioSource.clip = chargeSound;
                ourAudioSource.Play();
                chargeStarted = true;
                //set  to left charging animation
                gameObject.GetComponent<Animator>().Play("leftSquat");
            }
        }
    }

    //when right button held down

    public void RightHeld()
    {
        if (charge <= 8f)
            charge += 0.08f;

        AudioSource ourAudioSource = GetComponent<AudioSource>();

        if (!ourAudioSource.isPlaying && !chargeStarted)
        {
            if (touchingGround)
            {
                ourAudioSource.clip = chargeSound;
                ourAudioSource.Play();
                chargeStarted = true;
                //set to right charging animation
                gameObject.GetComponent<Animator>().Play("rightSquat");
            }
        }
    }

    //when left button released

    public void LeftReleased()
    {
        attemptJump = true;
        jumpDirection = -1;

        //set back to left default animation
        gameObject.GetComponent<Animator>().Play("leftTall");

        chargeStarted = false;

    }

    //when right button released


    public void RightReleased()
    {
        attemptJump = true;
        jumpDirection = 1;
        //set back to right default animation
        gameObject.GetComponent<Animator>().Play("rightTall");

        chargeStarted = false;

    }

    //constantly testing for player to jump

    public void FixedUpdate()
    {
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