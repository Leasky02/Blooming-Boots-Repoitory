using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//loads a new scene when the player collides with the end goal of a level.
public class LevelComplete : MonoBehaviour
{

    public string completeTag = "complete";
    public string levelToLoad;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(completeTag) == true)
        {
            SceneManager.LoadScene(levelToLoad);
        }

    }
}
