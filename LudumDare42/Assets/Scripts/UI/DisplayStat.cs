using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayStat : MonoBehaviour {

    public TextMeshPro TextDis { get; set; }
    private TrainCart trainCart;
    public string currentText;

	void Start () {
        trainCart = this.GetComponent<TrainCart>();
        TextDis = this.transform.GetChild(3).GetComponent<TextMeshPro>();
	}
	
	// Update is called once per frame
	void Update () {
        ChangeText("People: " + trainCart.numberOfPeople + "/" + TrainCart.MAX_PEOPLE);
        if (trainCart.numberOfPeople > TrainCart.MAX_PEOPLE)
        {
            TextDis.color = Color.red;
        } else
        {
            TextDis.color = Color.white;
        }
	}

    public void ChangeText(string text)
    {
        TextDis.text = text;
    }
}
