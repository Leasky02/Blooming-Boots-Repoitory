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
    public bool chargeStarted = false;

    public AudioClip landingSound;
    public AudioClip chargeSound;
    public AudioClip releaseSound;

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
    }


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
                gameObject.GetComponent<Animator>().Play("leftSquat");
            }
        }
    }

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
                gameObject.GetComponent<Animator>().Play("rightSquat");
            }
        }
    }

    public void LeftReleased()
    {
        attemptJump = true;
        jumpDirection = -1;

        gameObject.GetComponent<Animator>().Play("leftTall");

        AudioSource ourAudioSource = GetComponent<AudioSource>();
        ourAudioSource.clip = releaseSound;
        ourAudioSource.Play();
        chargeStarted = false;

    }

    public void RightReleased()
    {
        attemptJump = true;
        jumpDirection = 1;

        gameObject.GetComponent<Animator>().Play("rightTall");

        AudioSource ourAudioSource = GetComponent<AudioSource>();
        ourAudioSource.clip = releaseSound;
        ourAudioSource.Play();
        chargeStarted = false;

    }

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
        }
        attemptJump = false;
    }

}