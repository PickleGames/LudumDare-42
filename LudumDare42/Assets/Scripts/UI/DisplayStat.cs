using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayStat : MonoBehaviour {

    public TextMeshPro textDis;
    private TrainCart trainCart;

	void Start () {
        trainCart = this.GetComponent<TrainCart>();
	}
	
	// Update is called once per frame
	void Update () {
        textDis.text = "People: " + trainCart.numberOfPeople;
	}
}
