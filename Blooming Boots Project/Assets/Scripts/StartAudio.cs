using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudio : MonoBehaviour
{
    public GameObject frog;
    public GameObject frogAudio;
    public GameObject mushrooms1;
    public GameObject mushrooms2;
    public GameObject mushrooms3;
    public GameObject mushrooms4;
    public GameObject mushrooms5;
    public GameObject mushrooms6;
    public GameObject mushrooms7;
    public GameObject mushrooms8;
    public GameObject mushroomAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        frog.GetComponent<Animator>().Play("frog");
        frogAudio.GetComponent<AudioSource>().Play();

        mushrooms1.GetComponent<Animator>().Play("dancingMushrooms");
        mushrooms2.GetComponent<Animator>().Play("dancingMushrooms");
        mushrooms3.GetComponent<Animator>().Play("dancingMushrooms");
        mushrooms4.GetComponent<Animator>().Play("dancingMushrooms");
        mushrooms5.GetComponent<Animator>().Play("dancingMushrooms");
        mushrooms6.GetComponent<Animator>().Play("dancingMushrooms");
        mushrooms7.GetComponent<Animator>().Play("dancingMushrooms");
        mushrooms8.GetComponent<Animator>().Play("bigMush");

        mushroomAudio.GetComponent<AudioSource>().Play();
    }
}
