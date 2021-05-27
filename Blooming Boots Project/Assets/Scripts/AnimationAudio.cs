using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    
    public void PlayAudio()
    {
        audioSource.Play();
    }
}
