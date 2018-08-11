using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConductor : MonoBehaviour {

    public GameObject bg, fg;

    public float travelTime;
    public bool atStation;

	// Use this for initialization
	void Start () {
		
	}

    float tTimer;
	// Update is called once per frame
	void Update () {
        if (!atStation)
        {
            tTimer += Time.deltaTime;
            if (tTimer > travelTime)
            {
                tTimer = 0;
                atStation = true;
            }
        }

        if (atStation)
        {
            bg.GetComponentInChildren<Tiling>().station = true;
        }
	}
}
