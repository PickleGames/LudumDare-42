using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeBox : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip[] clips;
    public float loops;
    private float timesPlayed;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clips[Random.Range(0, clips.Length)];
        timesPlayed = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (!audioSource.isPlaying)
        {
            timesPlayed++;
            audioSource.Play();
            if(timesPlayed >= loops)
            {
                int newClip = Random.Range(0, clips.Length);
                while (clips[newClip] == audioSource.clip)
                {
                    newClip = Random.Range(0, clips.Length);
                }
                audioSource.clip = clips[newClip];
                timesPlayed = 0;
            }
        }
	}

    public void Play()
    {
        if (!audioSource.isPlaying)
            timesPlayed++;
            audioSource.Play();
    }
}
