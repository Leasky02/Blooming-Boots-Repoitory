using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int currentScore;
    public GameObject plantPot;
    public void ChangeScore()
    {
        currentScore++;
        GetComponent<Text>().text = "wells: " + currentScore + "/3";
        plantPot.GetComponent<strawberryAnimation>().ChangeAnimation(currentScore);
        //add change text to "wells:" + currentScore switch statement
    }
}
