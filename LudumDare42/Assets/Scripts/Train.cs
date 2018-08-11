using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour {

    public static bool IsAtTrainStation;
    public int NumberOfCart;
    public GameObject TrainCartFab;
    public List<GameObject> trainList;

	void Start () {
        trainList = new List<GameObject>();
        SpriteRenderer sp = TrainCartFab.GetComponentInChildren<SpriteRenderer>();
        for (int i = 0; i < NumberOfCart; i++)
        {
            GameObject go = Instantiate(TrainCartFab, new Vector3(transform.position.x - (i * sp.transform.localScale.x * sp.sprite.bounds.size.x + 1), 0, 0), Quaternion.identity, transform);
            trainList.Add(go);


        }
        
        
	}
	
	// Update is called once per frame
	void Update () {
        DeleteTrainCart();
	}

    private void DeleteTrainCart()
    {
        for(int i = 0; i < trainList.Count; i++)
        {
            if(trainList[i] == null)
            {
                for(int j = i + 1; j < trainList.Count; j++)
                {
                    if (trainList[j] == null) continue;
                    trainList[j].GetComponent<TrainCart>().BoomBoom();
                }
                break;
            }
        }
    }
}
