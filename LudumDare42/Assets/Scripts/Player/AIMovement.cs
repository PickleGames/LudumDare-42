using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour {
    public Vector2 movespeed;

    private Animator anim;
    private float moveSpeed;
    private bool wandering;
    private bool isWalking;
    private bool isWalkingRight;
    private bool isWalkingLeft;
    private Rigidbody2D rb;
    private AI ai;
    void Start()
    {
        moveSpeed = Random.Range(movespeed.x, movespeed.y);
        rb = this.GetComponent<Rigidbody2D>();
        ai = this.transform.GetComponent<AI>();
        anim = gameObject.GetComponent<Animator>();

    }

    void Update () {
        anim.SetBool("isWalking", isWalking);
        if (!ai.IsFly)
        {
            if (!wandering)
            {
                StartCoroutine(Wander());
                moveSpeed = Random.Range(movespeed.x, movespeed.y);
            }
            if (isWalking)
            {
                if (isWalkingRight)
                {
                    //Debug.Log("MOVING RIGHT");
                    rb.velocity = new Vector2(moveSpeed, 0);
                    transform.localScale = new Vector2(1,1);
                    //transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
                    //Debug.Log(isWalkingLeft);
                }
                if (isWalkingLeft)
                {
                    transform.localScale = new Vector2(-1, 1);
                    //Debug.Log("MOVING LEFT");
                    rb.velocity = new Vector2(-moveSpeed, 0);
                    //transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
                }
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
