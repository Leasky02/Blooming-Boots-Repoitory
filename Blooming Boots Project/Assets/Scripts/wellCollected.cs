using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wellCollected : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject scoreObject;
    public AudioClip fillBucket;

    private string playerTag = "Player";
    private bool alreadyAchieved = false;


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
