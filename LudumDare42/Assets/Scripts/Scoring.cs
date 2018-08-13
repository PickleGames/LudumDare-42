using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour {
    public static Scoring Instance;

    public GameConductor gameConductor;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI stopText;

    public int score = 0;

	// Use this for initialization
	void Start () {
        scoreText.text = "Dollar$: " + score;
        stopText.text = "Stops: " + gameConductor.stops + "/" + gameConductor.finalStop;
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Dollar$: " + score;
        stopText.text = "Stops: " + gameConductor.stops + "/" + gameConductor.finalStop;
    }

    public void AddScore(int increment)
    {
        score += increment;
    }

    float  timer = 0;
    public void AddScore(int increment, float delay)
    {
       
        timer += Time.deltaTime;
        if(timer > delay)
        {
            AddScore(increment);
            timer = 0;
        }
    }
}
