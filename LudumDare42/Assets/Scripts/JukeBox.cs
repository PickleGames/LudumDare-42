using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeBox : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip[] clips;
    public float numOfLoops;
    public float musicVolume;

    public bool isPlay; //Mute
    public static JukeBox Instance;
    private float timesPlayed;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Instance.clips = this.clips;
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clips[UnityEngine.Random.Range(0, clips.Length)];
        audioSource.loop = true;
        musicVolume = audioSource.volume; 
        audioSource.Play();
        isPlay = true;
        timesPlayed = 0;

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
            isPlay = true;
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
            isPlay = true;
        }
    }

    private AudioClip GetRandomAudioClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }

    public void ToggleMusic()
    {
        audioSource.volume = audioSource.volume != 0 ? 0 : 1;
        isPlay = !isPlay;
    }
}
