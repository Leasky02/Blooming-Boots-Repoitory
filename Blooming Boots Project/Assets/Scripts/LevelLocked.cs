using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//displays an object showing a padlock to indicate that it is locked when the playre attempts to
// go to that level
public class LevelLocked : MonoBehaviour
{
    public GameObject padlock;
    private string playerTag = "Player";

    //disables the object sprite rendered from the start
    private void Start()
    {
        padlock.GetComponent<SpriteRenderer>().enabled = false;
    }
    //when the player collides with the object
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag) == true)
        {
            padlock.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag) == true)
        {
            padlock.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

}
