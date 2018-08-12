using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConductor : MonoBehaviour {

    public GameObject parallax;
    public GameObject tunnel;
    public GameObject trainStation;

    public float travelTime;
    public float stationTime;
    private bool atStation;
	// Use this for initialization
	void Start () {
		
	}

    float tTimer, stimer;
	// Update is called once per frame
	void Update () {
     
        if (atStation)
        {
            stimer += Time.deltaTime;
            if(stimer > stationTime)
            {
                tunnel.GetComponent<Tunnel>().ResetTunnel();
                stimer = 0;            
                atStation = false;
            }
        }
        else
        {
            tTimer += Time.deltaTime;
            if (tTimer > travelTime)
            {
                tunnel.GetComponent<Tunnel>().ResetTunnel();
                tTimer = 0;
                atStation = true;
               
            }
        }


        if (tunnel.GetComponent<Tunnel>().InCenter())
        {
            if (atStation)
            {
                parallax.SetActive(false);
                trainStation.SetActive(true);
            }
            else
            {
                Debug.Log("TURN ON PARALLAX");
                parallax.SetActive(true);
                trainStation.SetActive(false);
            }
        }
	}

}
