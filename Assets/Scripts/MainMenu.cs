using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadEasy()
    {
        SceneManager.LoadScene(1); // load the easy scene
    }

    public void LoadMedium()
    {
        SceneManager.LoadScene(2); // load medium scene
    }

    public void LoadHard()
    {
        SceneManager.LoadScene(3); // load hard scene
    }

    public void QuitGame()
    {
        Application.Quit(); // quit game
    }
}
