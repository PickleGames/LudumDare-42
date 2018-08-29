using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeBox : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip[] clips;
    public float numOfLoops;
    //public bool isLoop;
    public static JukeBox Instance;
    private float timesPlayed;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clips[UnityEngine.Random.Range(0, clips.Length)];
        audioSource.loop = true;
        audioSource.Play();
        timesPlayed = 0;
        Instance = this;

    }
	
	// Update is called once per frame
	void Update () {
        //Juke();
	}

    public void Juke()
    {
        if (!audioSource.isPlaying)
        {
            timesPlayed++;
            audioSource.Play();
            if (timesPlayed > numOfLoops)
            {
                int newClip = UnityEngine.Random.Range(0, clips.Length);
                AudioClip clip = GetRandomAudioClip();
                while (clip == audioSource.clip)
                {
                    clip = GetRandomAudioClip();
                }
                audioSource.clip = clip;
                timesPlayed = 0;
            }
        }
    }

    public void PlaySound(string name, bool isLoop)
    {
        AudioClip audio = Array.Find(clips, music => music.name == name);

        if (audio != null)
        {
            //if (audioSource.clip != null && audioSource.clip.name == name)
            //{
            //    Debug.LogWarning("Audio name: \"" + name + "\" is already played.");
            //    return;
            //}
            audioSource.clip = audio;
            audioSource.loop = isLoop;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Audio name: \"" + name + "\" is not found.");
        }
    }

    public void Play()
    {
        if (!audioSource.isPlaying)
        {
            timesPlayed++;
            audioSource.Play();
        }
    }

    private AudioClip GetRandomAudioClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }
}
