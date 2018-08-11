using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour {

    public int NumberOfCart;
    public GameObject TrainCartFab;
    public List<GameObject> TrainList;

	void Start () {
        TrainList = new List<GameObject>();
        for (int i = 0; i < NumberOfCart; i++)
        {
            Instantiate(TrainCartFab, new Vector3(i * -1, 0, 0), Quaternion.identity, transform);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
