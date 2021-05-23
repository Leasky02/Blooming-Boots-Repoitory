using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointAnimation : MonoBehaviour
{
    private bool checkpointReached = false;
    private string playerTag = "Player";
    public AudioClip checkpointSound;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(playerTag) == true)
        {
            if (checkpointReached == false)
            {
                gameObject.GetComponent<Animator>().Play("checkpoint2");
                AudioSource ourAudioSource = GetComponent<AudioSource>();
                ourAudioSource.clip = checkpointSound;
                ourAudioSource.Play();
                checkpointReached = true;
            }
        }
    }
}
