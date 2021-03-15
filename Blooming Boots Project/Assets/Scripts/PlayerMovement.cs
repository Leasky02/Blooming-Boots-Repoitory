using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    public float jumpForce = 1000f;
    public int directionalForce = 130;
    public string groundTag = "Ground";
    private bool touchingGround = false;
    public float charge = 1;
    public bool justStarted = true;

    public AudioClip landingSound;
    public AudioClip chargeSound;

    public int jumpDirection = 0;
    public bool attemptJump = false;

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

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(groundTag) != true)
        {
            touchingGround = false;
        }
        AudioSource ourAudioSource = GetComponent<AudioSource>();
        ourAudioSource.Stop();
    }


    public void LeftHeld()
    {
        if(charge <= 6f)
            charge += 0.07f;

        gameObject.GetComponent<Animator>().Play("leftSquat");

        AudioSource ourAudioSource = GetComponent<AudioSource>();

        if(!ourAudioSource.isPlaying)
        {
            ourAudioSource.clip = chargeSound;
            ourAudioSource.Play();
        }
    }

    public void RightHeld()
    {
        if (charge <= 6f)
            charge += 0.07f;

        gameObject.GetComponent<Animator>().Play("rightSquat");

        AudioSource ourAudioSource = GetComponent<AudioSource>();

        if(!ourAudioSource.isPlaying)
        {
            ourAudioSource.clip = chargeSound;
            ourAudioSource.Play();
        }
    }

    public void LeftReleased()
    {
        attemptJump = true;
        jumpDirection = -1;

        gameObject.GetComponent<Animator>().Play("leftTall");

    }

    public void RightReleased()
    {
        attemptJump = true;
        jumpDirection = 1;

        gameObject.GetComponent<Animator>().Play("rightTall");

    }

    public void FixedUpdate()
    {
        if (touchingGround && attemptJump)
        {
            Rigidbody2D ourRigidbody = GetComponent<Rigidbody2D>();
            ourRigidbody.AddForce(Vector2.up * jumpForce * charge);
            Vector2 jumpDirectionVector = jumpDirection == 1 ? Vector2.right : Vector2.left;
            ourRigidbody.AddForce(jumpDirectionVector * directionalForce * charge);
            charge = 1f;
            touchingGround = false;
        }
        attemptJump = false;
    }

}