using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCart : MonoBehaviour {

    public const int MAX_PEOPLE = 10;
    public const float DURABILITY_DAMAGE = 0.1f;
    public const float TIME_DESTROY = 2f;

    public bool IsBreak { get; set; }
    public int numberOfPeople;
    public float Durability { get; private set; }

    public List<GameObject> aiList;
    private float timeElapsed;

    void Start () {
        aiList = new List<GameObject>();
        Durability = 100;    	
	}
	
	void Update () {

        Scoring.Instance.AddScore(10*numberOfPeople, 2);

        if (!Train.IsAtTrainStation)
        {
            ReduceDurability();
        }

        if (IsBreak)
        {
            timeElapsed += Time.deltaTime;
        }

        if(timeElapsed >= TIME_DESTROY)
        {
            Destroy(transform.gameObject);
            KillAll();
        }
	}

    public int GainPoints()
    {
        return numberOfPeople != 0 ? Mathf.Clamp(numberOfPeople + MAX_PEOPLE, 10, 20) : 0;
    }

    public void BoomBoom()
    {
        IsBreak = true;
    }

    public void RemovePeople(GameObject go)
    {
        Debug.Log("ai remove");
        numberOfPeople -= 1;
        aiList.Remove(go);
    }

    public void ChangePeopleRenderer(bool isEnable)
    {
        for (int i = 0; i < aiList.Count; i++)
        {
            SpriteRenderer sr = aiList[i].GetComponentInChildren<SpriteRenderer>();
            sr.enabled = isEnable;
        }
    }

    public void KillAll()
    {
        for (int i = 0; i < aiList.Count; i++)
        {
            aiList[i].GetComponent<AI>().FlyAway();

        }
    }

    private void ReduceDurability()
    {
        if(numberOfPeople > MAX_PEOPLE)
        {
            Durability -= DURABILITY_DAMAGE * (numberOfPeople / MAX_PEOPLE);
        }
        if (Durability <= 0) IsBreak = true;
    }

    // check if AI have entered and exited train cart area, adjust contacts accordingly
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AI"))
        {
            numberOfPeople += 1;
            aiList.Add(collision.gameObject);
            collision.gameObject.GetComponent<AI>().trainCart = this;
        }

    }

}
