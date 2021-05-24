using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointAnimation : MonoBehaviour
{
    public AudioClip checkpointSound;
    public void PlayCheckpointAnimation()
    {

        gameObject.GetComponent<Animator>().Play("checkpoint2");
        AudioSource ourAudioSource = GetComponent<AudioSource>();
        ourAudioSource.clip = checkpointSound;
        ourAudioSource.Play();
    }

}
