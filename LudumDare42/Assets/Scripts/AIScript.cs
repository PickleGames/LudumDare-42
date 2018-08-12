using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour {
    public float movespeed;

    private bool wandering;
    private bool isWalking;
    private bool isWalkingRight;
    private bool isWalkingLeft;

    void Update () {



        if (!wandering)
        {
            StartCoroutine(Wander());
        }
        if (isWalking)
        {
            if (isWalkingRight)
            {
                Debug.Log("MOVING RIGHT");
                transform.Translate(movespeed * Time.deltaTime, 0, 0);
                Debug.Log(isWalkingLeft);
            }
            if (isWalkingLeft)
            {
                Debug.Log("MOVING LEFT");
                transform.Translate(-movespeed * Time.deltaTime, 0, 0);
            }
        } 
	}

    IEnumerator Wander()
    {
        int isWalkingDirection = Random.Range(1, 3);
        int walkwait = Random.Range(1,3);
        int walktime = Random.Range(1,3);

        wandering = true;

        yield return new WaitForSeconds(walkwait);
        isWalking = true;

        if (isWalkingDirection == 1)
        {
            isWalkingRight = true;
            isWalkingLeft = false;
        }
        if (isWalkingDirection == 2)
        {
            isWalkingLeft = true;
            isWalkingRight = false;
        }
        yield return new WaitForSeconds(walktime);
        isWalking = false;

        wandering = false;

    }
}
