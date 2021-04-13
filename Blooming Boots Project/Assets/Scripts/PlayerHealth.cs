using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth;
    int currentHealth;
    public string levelToLoad;

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
}
