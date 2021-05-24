using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strawberryAnimation : MonoBehaviour
{
    private int timer = 0;
    private bool startTimer = false;
    private bool fruitGrown = false;
    private string playerTag = "Player";

    public int fruitTime;
    public AudioClip bite;
    public void ChangeAnimation(int score)
    {
        switch (score)
        {
            case 1:
                gameObject.GetComponent<Animator>().Play("animation 1");
                break;
            case 2:
                gameObject.GetComponent<Animator>().Play("animation 2");
                break;
            case 3:
                gameObject.GetComponent<Animator>().Play("animation 3");
                startTimer = true;
                break;
        }
    }
    public void FixedUpdate()
    {
        if(startTimer)
        {
            timer++;
        }

        if(timer > fruitTime)
        {
            gameObject.GetComponent<Animator>().Play("animation complete");
            fruitGrown = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag) == true)
        {
            if (fruitGrown)
            {
                AudioSource ourAudioSource = GetComponent<AudioSource>();
                ourAudioSource.clip = bite;
                ourAudioSource.Play();
                timer = 0;
                Debug.Log("timer set to 0 and fruit grown = false");
                fruitGrown = false;
                gameObject.GetComponent<Animator>().Play("animation 3");
            }
        }
    }
}

