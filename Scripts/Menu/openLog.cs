using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openLog : MonoBehaviour
{
    public void openLogbook()
    {
        SceneManager.LoadScene("Log");
        Debug.Log(SceneManager.GetActiveScene().name);
    }
}
