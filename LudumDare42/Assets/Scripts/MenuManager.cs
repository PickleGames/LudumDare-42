using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour {

    public void PlayGame(string levels)
    {
        Debug.Log("Loading GAME...");
        Time.timeScale = 1;
        SceneManager.LoadScene(levels);
    }

    public void ExitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
