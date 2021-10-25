using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToMain : MonoBehaviour
{
    public void home(){
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Log"){

            SceneManager.LoadScene("MainMenu");
        }
     
        else if (openAddBehaviour.openendFromLog)
        {
        SceneManager.LoadScene("Log");
        }
        else
        {
         SceneManager.LoadScene("MainMenu");
        }

    }
    
}

