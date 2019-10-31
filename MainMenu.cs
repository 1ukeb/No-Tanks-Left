using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Loads the next scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + Random.Range(1,3)); //Loads the next scene but random (random maps)
    }

    public void quitGame()
    {
        Debug.Log("Successfully quit application!");
        Application.Quit();
    }
}
