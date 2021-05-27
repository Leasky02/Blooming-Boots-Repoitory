using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//plays the audio and animation when player reaches the checkpoint
public class checkpointAnimation : MonoBehaviour
{
    //variable with the audio clip that will be played
    public AudioClip checkpointSound;
    //function when collided with player
    public void PlayCheckpointAnimation()
    {
        gameObject.GetComponent<Animator>().Play("checkpoint2");
        AudioSource ourAudioSource = GetComponent<AudioSource>();
        ourAudioSource.clip = checkpointSound;
        ourAudioSource.Play();
    }

}
