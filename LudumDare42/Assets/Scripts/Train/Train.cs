using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour {

    public static bool IsAtTrainStation;
    public int NumberOfCart;
    public GameObject TrainCartFab;
    public List<GameObject> trainList;

    public GameObject player;
    public int playerTrainCartPosition;

    //0: front 1:mid 2:front_tran 3:mid_tran 4:front_break 5:mid_break 
    public Sprite[] trainSprite; 

	void Start () {
        trainList = new List<GameObject>();
        foreach (Transform child in transform)
        {
            if (child.CompareTag("TrainCart")){
                trainList.Add(child.gameObject);
            }
        }
        //SpawnTrain();
        ChangeCartSprite(playerTrainCartPosition, true);
    }
	


	void Update () {
        DeleteTrainCart();

	}

    public void ChangeCompartment(Direction direction)
    {
        ChangeCartSprite(playerTrainCartPosition, false);
        if (direction == Direction.Left) 
        {
            if (playerTrainCartPosition < 4) playerTrainCartPosition++;
        }
        else if(direction == Direction.Right) 
        {
            if(playerTrainCartPosition > 0) playerTrainCartPosition--;
        }
        TeleportPlayer(playerTrainCartPosition, direction);
        ChangeCartSprite(playerTrainCartPosition, true);
    }

    private void TeleportPlayer(int index, Direction direction)
    {
        Transform t = trainList[index].transform;
        SpriteRenderer sp = TrainCartFab.GetComponentInChildren<SpriteRenderer>();
        if (direction == Direction.Left)
        {
            player.transform.position = new Vector2(t.position.x + ((TrainCartFab.transform.localScale.x * sp.transform.localScale.x * sp.sprite.bounds.size.x) / 2) * .7f,
                                                    player.transform.position.y);
        }else if (direction == Direction.Right)
        {
            player.transform.position = new Vector2(t.position.x - ((TrainCartFab.transform.localScale.x * sp.transform.localScale.x * sp.sprite.bounds.size.x) / 2) * .7f,
                                                    player.transform.position.y);
        }
    }

    private void ChangeCartSprite(int trainIndex, bool isInside)
    {
        int spriteValue = 0;
        if (trainIndex == 0)
        {
            if (isInside)
            {
                spriteValue = 2;
            }
            else
            {
                spriteValue = 0;
            }
        }
        else
        {
            if (isInside)
            {
                spriteValue = 3;
            }
            else
            {
                spriteValue = 1;
            }
        }
        trainList[trainIndex].GetComponentInChildren<SpriteRenderer>().sprite = trainSprite[spriteValue];
    }

    private void SpawnTrain()
    {
        SpriteRenderer sp = TrainCartFab.GetComponentInChildren<SpriteRenderer>();
        for (int i = 0; i < NumberOfCart; i++)
        {
            GameObject go = Instantiate(TrainCartFab, new Vector3(transform.position.x -
                                        (i * TrainCartFab.transform.localScale.x * sp.transform.localScale.x * sp.sprite.bounds.size.x),
                                            0, 0), Quaternion.identity, transform);
            if (i == 0) go.GetComponentInChildren<SpriteRenderer>().sprite = trainSprite[0];
            trainList.Add(go);
        }
    }

    private void DeleteTrainCart()
    {
        for (int i = 0; i < trainList.Count; i++)
        {
            if (trainList[i] == null)
            {
                for (int j = i + 1; j < trainList.Count; j++)
                {
                    if (trainList[j] == null) continue;
                    trainList[j].GetComponent<TrainCart>().BoomBoom();
                }
                break;
            }
        }
    }



}
