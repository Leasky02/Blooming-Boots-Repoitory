using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignPostLeftScript : MonoBehaviour
{
    public string levelToLoad;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {

        if (otherCollider.tag == "Player")
            SceneManager.LoadScene(levelToLoad);
    }
}