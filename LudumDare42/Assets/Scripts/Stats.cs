using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour {
    public TextMeshProUGUI[] statTexts;
    public string[] statNames;
    public float[] statNums;
    public static Stats instance;
	// Use this for initialization
	void Start () {
        instance = this;
        DontDestroyOnLoad(this);
		for(int i = 0; i < statTexts.Length; i++)
        {
            statTexts[i].text = statNames[i] + ": " + statNums;
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < statTexts.Length; i++)
        {
            statTexts[i].text = statNames[i] + ": " + statNums;
        }
    }
}
