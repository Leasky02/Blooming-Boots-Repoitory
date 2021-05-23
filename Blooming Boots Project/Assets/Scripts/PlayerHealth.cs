using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth;
    int currentHealth;
    public string levelToLoad;
    public string checkpointLevel;

    //public float alphaLevel = 5f;

    private bool startTimer = false;
    private int time = 0;

    public string checkpoint = "checkpoint";
    private bool checkpointReached = false;

    void Awake()
    {
        currentHealth = startingHealth;
    }

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

    //function that will be called when a collision occurs
    public void Kill()
    {
        startTimer = true;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    //testing for a checkpoint
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(checkpoint) == true)
        {
            if(checkpointReached == false)
            {
                levelToLoad = checkpointLevel;
                checkpointReached = true;
            }
        }
    }

    public void FixedUpdate()
    {
        if(startTimer)
        {
            time++;
            if(time >= 50)
            {
                SceneManager.LoadScene(levelToLoad);
            }
            //alphaLevel -= 0.05f;
            //GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaLevel);
        }
    }
}
