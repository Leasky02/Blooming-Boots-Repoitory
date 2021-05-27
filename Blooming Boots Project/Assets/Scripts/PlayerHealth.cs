using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//controls player health and checkpoints
public class PlayerHealth : MonoBehaviour
{
    public int startingHealth;
    int currentHealth;
    public string levelToLoad;
    public string checkpointLevel;
    public string character;

    //public float alphaLevel = 5f;

    private bool startTimer = false;
    private int time = 0;

    public string checkpoint = "checkpoint";
    private bool checkpointReached = false;

    void Awake()
    {
        currentHealth = startingHealth;
    }
    //called when damage is taken from other hazard scripts
    public void ChangeHealth(int changeAmount)
    {
        currentHealth = currentHealth + changeAmount;
        //keep health between 0 and starting health
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);

        if(currentHealth == 0)
        {
            Kill();
        }

    }

    //function that will be called when the players health goes to 0
    public void Kill()
    {
        startTimer = true;
        GetComponent<PlayerMovement2>().dead = true;

        switch (character)
        {
            case "purple":
                gameObject.GetComponent<Animator>().Play("purpleGrave");
                break;

            case "yellow":
                gameObject.GetComponent<Animator>().Play("yellowGrave");
                break;

            case "red":
                gameObject.GetComponent<Animator>().Play("redGrave");
                break;

            case "main":
                gameObject.GetComponent<Animator>().Play("mainGrave");
                break;

            case "green":
                gameObject.GetComponent<Animator>().Play("greenGrave");
                break;
        }
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    //testing for a checkpoint
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collision");
        if (collision.CompareTag(checkpoint) == true)
        {
            //Debug.Log("collided with checkpoint");
            if(checkpointReached == false)
            {
                //Debug.Log("Checkpoint reached");
                levelToLoad = checkpointLevel;
                checkpointReached = true;
                collision.GetComponent<checkpointAnimation>().PlayCheckpointAnimation();
            }
        }
    }
    //controls the timer upon death
    public void FixedUpdate()
    {
        if(startTimer)
        {
            time++;
            if(time >= 45)
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }
    //gets the current character in order to determine what death animation to play
    private void Update()
    {
        character = GetComponent<PlayerMovement2>().activeCharacter;
    }
}
