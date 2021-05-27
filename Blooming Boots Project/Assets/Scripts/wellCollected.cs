using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wellCollected : MonoBehaviour
{
    public GameObject scoreObject;
    public AudioClip fillBucket;

    private string playerTag = "Player";
    private bool alreadyAchieved = false;

    //calls to set the score to display a well has been found and play 
    // a sound and change the sprite and make the well un interactable after the first collision
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag) == true)
        {
            if(!alreadyAchieved)
            {
                alreadyAchieved = true;
                gameObject.GetComponent<Animator>().Play("well unlit");

                AudioSource ourAudioSource = GetComponent<AudioSource>();
                ourAudioSource.clip = fillBucket;
                ourAudioSource.Play();
                scoreObject.GetComponent<Score>().ChangeScore();
            }
        }
    }
}
