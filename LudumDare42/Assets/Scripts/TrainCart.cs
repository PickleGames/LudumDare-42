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

    private float timeElapsed;

    void Start () {
        Durability = 100;    	
	}
	
	void Update () {
		if(!Train.IsAtTrainStation)
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

    private void ReduceDurability()
    {
        if(numberOfPeople > MAX_PEOPLE)
        {
            Durability -= DURABILITY_DAMAGE * (numberOfPeople / MAX_PEOPLE);
        }
        if (Durability <= 0) IsBreak = true;
    }


}
