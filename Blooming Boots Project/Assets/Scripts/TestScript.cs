using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    //variables thatll be used in unity
    public string startText;
    public int score;
    public int repeatedScore;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(startText);
        score = 0;
        repeatedScore = 1;
    }

    // Update is called once per frame
    void Update()
    {
        score += 1;
        if(score==1000)
        {
            Debug.Log("Score reached 1000 x" + repeatedScore);
            score = 0;
            repeatedScore += 1;
        }
        else
        {
            Debug.Log("Testing score");
        }

    }
}
