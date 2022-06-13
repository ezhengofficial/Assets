using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        int index = Random.Range(1,3);
        SceneManager.LoadScene(index);
        Debug.Log("scene loaded");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application Quit...");
    }
}
