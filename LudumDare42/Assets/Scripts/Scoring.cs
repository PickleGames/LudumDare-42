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
        Instance = this;
        UpdateStatText();

    }
	
	// Update is called once per frame
	void Update () {
        UpdateStatText();
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

    private void UpdateStatText()
    {
        scoreText.text = "Dollar: $" + score;
        stopText.text = "Stops: " + gameConductor.stops + "/" + gameConductor.finalStop;
    }
}
