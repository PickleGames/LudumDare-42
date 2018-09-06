using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        try
        {
            JukeBox juke = JukeBox.Instance;
            bool isMusicMute = juke.isPlay;
            this.GetComponent<Toggle>().isOn = isMusicMute;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void Awake()
    {
        Toggle t = this.GetComponent<Toggle>();
        t.onValueChanged.AddListener((value) => {
            JukeBox.Instance.ToggleMusic();
        }
        );
    }

    // Update is called once per frame
    void Update () {
		
	}
}
