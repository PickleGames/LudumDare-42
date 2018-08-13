using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour {

    public TextMeshProUGUI scoreText;
    private int score = 0;

	// Use this for initialization
	void Start () {
        scoreText.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score;
        AddScore(10, 2);
    }

    public void AddScore(int increment)
    {
        score += increment;
    }

    float timer = 0;
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
