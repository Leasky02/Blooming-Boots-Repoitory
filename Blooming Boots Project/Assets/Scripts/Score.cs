using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//changes the text to display how many wells have been found
public class Score : MonoBehaviour
{
    public int currentScore;
    public GameObject plantPot;
    public void ChangeScore()
    {
        currentScore++;
        GetComponent<Text>().text = "Wells: " + currentScore + "/3";
        plantPot.GetComponent<strawberryAnimation>().ChangeAnimation(currentScore);
        //add change text to "wells:" + currentScore switch statement
    }
}
