using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    public static bool isPaused = false;
    public GameObject backgroundButton;

    public GameObject backgroundStop;
    public GameObject foreGroundStop;
    public GameObject shadowGroundStop;
    public GameObject pauseUI;

    void Start()
    {

    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    private void Resume ()
    {
        foreach (Transform child in backgroundStop.transform)
        {
            child.GetComponent<Tiling>().moveSpeed = 0.2f;
        }
        foreach (Transform child in foreGroundStop.transform)
        {
            child.GetComponent<Tiling>().moveSpeed = 0.5f;
        }
        foreach (Transform child in shadowGroundStop.transform)
        {
            child.GetComponent<Tiling>().moveSpeed = 0.5f;
        }
        //backgroundStop.GetComponent<Tiling>().moveSpeed = 0.2f;
        //foreGroundStop.GetComponent<Tiling>().moveSpeed = 0.5f;
        //shadowGroundStop.GetComponent<Tiling>().moveSpeed = 0.5f;
        pauseUI.SetActive(false);
        backgroundButton.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

    }

    private void Pause()
    {
        foreach(Transform child in backgroundStop.transform)
        {
            child.GetComponent<Tiling>().moveSpeed = 0f;
        }
        foreach (Transform child in foreGroundStop.transform)
        {
            child.GetComponent<Tiling>().moveSpeed = 0f;
        }
        foreach (Transform child in shadowGroundStop.transform)
        {
            child.GetComponent<Tiling>().moveSpeed = 0f;
        }

        backgroundButton.SetActive(true);
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void PauseButton()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
}
