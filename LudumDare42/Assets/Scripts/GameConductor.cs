using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameConductor : MonoBehaviour {

    public GameObject parallax;
    public GameObject tunnel;
    public GameObject trainStation;
    public GameObject trainStationEnd;
    public float finalStop;
    private int stops;

    public float travelTime;
    public float stationTime;
    private bool atStation;
	// Use this for initialization
	void Start () {
        stops = 1;
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
                parallax.SetActive(true);
                trainStationEnd.SetActive(false);
                stops++;
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
                trainStation.GetComponentInChildren<AI_Spawner>().currentMax = (AI_Spawner.MAX_AI * stops);
            }
        }


        if (tunnel.GetComponent<Tunnel>().InCenter())
        {
            if (atStation)
            {
                parallax.SetActive(false);
                trainStation.SetActive(true);
                trainStationEnd.SetActive(true);
            }
            else
            {
                parallax.SetActive(true);
                trainStation.SetActive(false);
            }
        }

        if(stops > finalStop)
        {
            Debug.Log("YOU WIN BITCH!!\nYOU WIN BITCH!!\n THAT'S RIGHT MUDAFAKA!!\nYOU FAKIN WIN BOOIIII!");
            tTimer = 0;
            stimer = 0;
            SceneManager.LoadScene("WIN");
        }
	}

}
