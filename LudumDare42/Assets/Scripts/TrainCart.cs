using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCart : MonoBehaviour {

    public const int MAX_PEOPLE = 10;
    public int NumberOfPoeple { get; private set; }
    public float Durability { get; private set; }

    void Start () {
        Durability = 100;    	
	}
	
	void Update () {
		
	}
}
