using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{

    public string completeTag = "complete";
    public string levelToLoad;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(completeTag) == true)
        {
            SceneManager.LoadScene(levelToLoad);
            /* add in text saying "level 1 complete" with a timer 
             * along with a success sound which then loads the next scene
             * also unlock level 2 */
        }

    }
}
