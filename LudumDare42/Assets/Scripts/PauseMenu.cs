using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public static bool isPaused = false;

    public GameObject pauseUI;
	void Update () {
        if (Input.GetKeyDown(Keycode.Escape))
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

    void Resume ()
    {

    }
}
