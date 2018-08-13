using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour {
    public static Scoring Instance;
    public TextMeshProUGUI scoreText;
    public int score = 0;

	// Use this for initialization
	void Start () {
        scoreText.text = "Score: " + score;
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score;
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
