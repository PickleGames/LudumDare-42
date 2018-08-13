using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour {
    public AudioSource GameMusic;


    public void playGame(int levels)
    {
        Debug.Log("Loading GAME...");
        SceneManager.LoadScene(levels);
    }

    public void exitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
