using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlants : MonoBehaviour
{
    public void MainChosen()
    {
        gameObject.GetComponent<Animator>().Play("otherPlants");
    }

    public void PurpleChosen()
    {
        gameObject.GetComponent<Animator>().Play("withoutPurple");
    }

    public void YellowChosen()
    {
        gameObject.GetComponent<Animator>().Play("withoutYellow");
    }

    public void RedChosen()
    {
        gameObject.GetComponent<Animator>().Play("withoutRed");
    }

    public void GreenChosen()
    {
        gameObject.GetComponent<Animator>().Play("withoutGreen");
    }
}

