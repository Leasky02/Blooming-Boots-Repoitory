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

    public string checkpoint = "checkpoint";
    public AudioClip checkpointSound;
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
        
        SceneManager.LoadScene(levelToLoad);
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
                AudioSource ourAudioSource = GetComponent<AudioSource>();
                ourAudioSource.clip = checkpointSound;
                ourAudioSource.Play();
                checkpointReached = true;
            }
        }
    }
}
