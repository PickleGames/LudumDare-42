using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConductor : MonoBehaviour {

    public GameObject parallax;
    public GameObject tunnel;
    public GameObject trainStation;
    public float finalStop;
    private int stops;

    public float travelTime;
    public float stationTime;
    private bool atStation;
	// Use this for initialization
	void Start () {
        stops = 0;
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
                stops++;
                trainStation.GetComponentInChildren<AI_Spawner>().currentMax = (AI_Spawner.MAX_AI * stops);
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

        if(stops >= finalStop)
        {
            Debug.Log("YOU WIN BITCH!!\nYOU WIN BITCH!!\n THAT'S RIGHT MUDAFAKA!!\nYOU FAKIN WIN BOOIIII!");
            tTimer = 0;
            stimer = 0;
        }
	}

}
