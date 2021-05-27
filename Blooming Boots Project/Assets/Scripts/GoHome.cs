using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : MonoBehaviour
{
    //transports player back to the start of the game complete level
    public void Return()
    {
        GetComponent<Transform>().position = new Vector3(1, 1, 0);
    }
}
