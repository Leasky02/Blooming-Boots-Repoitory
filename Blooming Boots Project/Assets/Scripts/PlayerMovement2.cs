using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    //variables relating to collisions and movement
    public Collider2D groundSensor;
    public float jumpForce = 1000f;
    public int directionalForce = 130;
    public string groundTag = "Ground";
    public int hazardDamage;

    public string activeCharacter = "main";

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

                switch(activeCharacter)
                {
                    case "purple":
                        gameObject.GetComponent<Animator>().Play("PURPLEleftSquat");
                        break;

                    case "yellow":
                        gameObject.GetComponent<Animator>().Play("YELLOWleftSquat");
                        break;

                    case "red":
                        gameObject.GetComponent<Animator>().Play("REDleftSquat");
                        break;

                    case "main":
                        gameObject.GetComponent<Animator>().Play("leftSquat");
                        break;

                    case "green":
                        gameObject.GetComponent<Animator>().Play("GREENleftSquat");
                        break;
                }

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

                switch (activeCharacter)
                {
                    case "purple":
                        gameObject.GetComponent<Animator>().Play("PURPLErightSquat");
                        break;

                    case "yellow":
                        gameObject.GetComponent<Animator>().Play("YELLOWrightSquat");
                        break;

                    case "red":
                        gameObject.GetComponent<Animator>().Play("REDrightSquat");
                        break;

                    case "main":
                        gameObject.GetComponent<Animator>().Play("rightSquat");
                        break;

                    case "green":
                        gameObject.GetComponent<Animator>().Play("GREENrightSquat");
                        break;
                }

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

        switch (activeCharacter)
        {
            case "purple":
                gameObject.GetComponent<Animator>().Play("PURPLEleftTall");
                break;

            case "yellow":
                gameObject.GetComponent<Animator>().Play("YELLOWleftTall");
                break;

            case "red":
                gameObject.GetComponent<Animator>().Play("REDleftTall");
                break;

            case "main":
                gameObject.GetComponent<Animator>().Play("leftTall");
                break;

            case "green":
                gameObject.GetComponent<Animator>().Play("GREENleftTall");
                break;
        }


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

        switch (activeCharacter)
        {
            case "purple":
                gameObject.GetComponent<Animator>().Play("PURPLErightTall");
                break;

            case "yellow":
                gameObject.GetComponent<Animator>().Play("YELLOWrightTall");
                break;

            case "red":
                gameObject.GetComponent<Animator>().Play("REDrightTall");
                break;

            case "main":
                gameObject.GetComponent<Animator>().Play("rightTall");
                break;

            case "green":
                gameObject.GetComponent<Animator>().Play("GREENrightTall");
                break;
        }

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


    public void PurplePlant()
    {
        activeCharacter = "purple";
        jumpForce = 500;
        directionalForce = 900;
        Debug.Log("purple");
        gameObject.GetComponent<Animator>().Play("PURPLErightTall");
    }

    public void YellowPlant()
    {
        activeCharacter = "yellow";
        jumpForce = 1100;
        directionalForce = 500;
        Debug.Log("yellow");
        gameObject.GetComponent<Animator>().Play("YELLOWrightTall");
    }

    public void RedPlant()
    {
        activeCharacter = "red";
        jumpForce = 1100;
        directionalForce = 200;
        Debug.Log("red");
        gameObject.GetComponent<Animator>().Play("REDrightTall");
    }

    public void MainPlant()
    {
        activeCharacter = "main";
        jumpForce = 800;
        directionalForce = 600;
        Debug.Log("main");
        gameObject.GetComponent<Animator>().Play("rightTall");
    }

    public void GreenPlant()
    {
        activeCharacter = "green";
        jumpForce = 300;
        directionalForce = 900;
        Debug.Log("green");
        gameObject.GetComponent<Animator>().Play("GREENrightTall");
    }
}