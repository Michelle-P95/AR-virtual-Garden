using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openAddBehaviour : MonoBehaviour
{

    public static bool openendFromLog = false; 
    public void openBehaviour()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("AddBehaviourMenu");
        Debug.Log(SceneManager.GetActiveScene().name);

        if (currentScene.name == "Log"){
            openendFromLog = true; 
            }

        else if (currentScene.name == "MainMenu"){
            openendFromLog = false; 

        }
        
        
    }
}
