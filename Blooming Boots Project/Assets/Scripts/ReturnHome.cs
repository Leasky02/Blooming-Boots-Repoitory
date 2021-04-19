using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnHome : MonoBehaviour
{
    public string levelToLoad;

    public void GoHome()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
