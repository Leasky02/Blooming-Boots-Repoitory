using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//determines which scene to load for the button connected
public class ButtonActions : MonoBehaviour
{
    public string levelToLoad;
    //function to load the scene set in the variable
    public void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }

}

