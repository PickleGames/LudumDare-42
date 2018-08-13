using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMiniMap : MonoBehaviour {

    public Train targetTrain;
    public List<TrainCart> targetCartList;

    private Train currentTrain;

    void Start () {
        currentTrain = this.GetComponent<Train>();
        foreach (Transform child in targetTrain.transform)
        {
            if (child.CompareTag("TrainCart"))
            {
                targetCartList.Add(child.GetComponent<TrainCart>());
            }
        }


    }
	
	// Update is called once per frame
	void Update () {
        currentTrain.playerTrainCartPosition = targetTrain.playerTrainCartPosition;
        for(int i = 0; i < currentTrain.trainList.Count; i++)
        {
            if (currentTrain.trainList[i] == null || targetCartList[i] == null) continue;
            TrainCart tc = currentTrain.trainList[i].GetComponent<TrainCart>();
            SpriteRenderer sr = tc.transform.GetComponentInChildren<SpriteRenderer>();

            tc.numberOfPeople = targetCartList[i].numberOfPeople;
            tc.Durability = targetCartList[i].Durability;
            tc.IsBreak = targetCartList[i].IsBreak;
            sr.sprite = targetCartList[i].transform.GetComponentInChildren<SpriteRenderer>().sprite;
        }
	}

}
