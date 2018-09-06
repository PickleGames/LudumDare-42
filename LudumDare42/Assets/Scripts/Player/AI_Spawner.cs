using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Spawner : MonoBehaviour {
    public Train train;
    public int currentMax;
    private List<GameObject> bois;
    public float speed;
    public const int MAX_AI = 10;
    public GameObject[] spawnPoints;
    public GameObject[] boardPoints;
    public GameObject AI;
    public GameObject parent;

	// Use this for initialization
	void Start () {
        bois = new List<GameObject>();

      
    }
	
	// Update is called once per frame
	void Update () {


        while (bois.Count < currentMax)
        {
            GameObject aiClone = SpawnBoi();
            bois.Add(aiClone);
            aiClone.GetComponent<Rigidbody2D>().gravityScale = 0;
            aiClone.GetComponent<AIMovement>().enabled = false;
            aiClone.GetComponent<AI>().enabled = false;
            aiClone.GetComponentInChildren<SpriteRenderer>().enabled = true;
            BoardTrain(aiClone);
        }

        for (int i = 0; i < boardPoints.Length; i++)
        {
            foreach (GameObject go in bois)
            {
                if (InRange(go.transform, boardPoints[i].transform, 1))
                {
                    go.transform.position = new Vector2(go.transform.position.x, go.transform.position.y + 1);
                    BackToLife(go);
                }
            }
        }
        
        for(int i = 0; i < bois.Count; i++)
        {
            if (bois[i] == null || !bois[i].GetComponent<BoxCollider2D>().enabled)
            {
                bois.Remove(bois[i]);
            }
        }
        //foreach(GameObject go in bois)
        //{
        //    if (go == null || !go.GetComponent<BoxCollider2D>().enabled)
        //        bois.Remove(go);
        //}
            
    }

    private GameObject SpawnBoi()
    {
        //Debug.Log("train num : " + train.trainList.Count);
        Transform spawn = spawnPoints[Random.Range(0, train.trainList.Count)].transform;
        return Instantiate<GameObject>(AI, spawn.position, this.transform.rotation, parent.transform);
    }

    private void BoardTrain(GameObject ai)
    {
        //Debug.Log("train num : " + train.trainList.Count);
        Vector2 direction = boardPoints[Random.Range(0, train.trainList.Count)].transform.position - ai.transform.position;
        direction.Normalize();

        ai.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * speed;       
    }

    private bool InRange(Transform p1, Transform p2, float range)
    {
        return Distance(p1.position, p2.position) <= range;       
    }

    public float Distance(Vector2 p1, Vector2 p2)
    {
        return Mathf.Sqrt(Mathf.Pow(p2.x - p1.x, 2) + Mathf.Pow(p2.y - p1.y, 2));
    }

    public void BackToLife(GameObject go)
    {
        go.GetComponent<Rigidbody2D>().gravityScale = 1;
        go.GetComponent<AIMovement>().enabled = true;
        go.GetComponent<AI>().enabled = true;
        go.GetComponentInChildren<SpriteRenderer>().enabled = false;
        train.trainList[train.playerTrainCartPosition].GetComponent<TrainCart>().ChangePeopleRenderer(true);
    }
}
