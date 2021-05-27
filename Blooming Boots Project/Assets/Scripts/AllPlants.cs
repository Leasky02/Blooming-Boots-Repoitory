using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//controls the animation in game complete level to switch out the current playable plant
public class AllPlants : MonoBehaviour
{
    //main plant chosen
    public void MainChosen()
    {
        gameObject.GetComponent<Animator>().Play("otherPlants");
    }
    //purple plant chosen
    public void PurpleChosen()
    {
        gameObject.GetComponent<Animator>().Play("withoutPurple");
    }
    //yellow plant chosen
    public void YellowChosen()
    {
        gameObject.GetComponent<Animator>().Play("withoutYellow");
    }
    //red plant chosen
    public void RedChosen()
    {
        gameObject.GetComponent<Animator>().Play("withoutRed");
    }
    //green plant chosen
    public void GreenChosen()
    {
        gameObject.GetComponent<Animator>().Play("withoutGreen");
    }
}

