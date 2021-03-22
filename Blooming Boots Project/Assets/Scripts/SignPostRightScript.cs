using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignPostRightScript : MonoBehaviour
{
    public string levelToLoad;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Debug.Log("trigger occured");

        if(otherCollider.tag == "Player")
            SceneManager.LoadScene(levelToLoad);
    }
}
