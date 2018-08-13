using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 5;
    public SpeechBubble speechBubble;

    private Animator animator;
    private BoxCollider2D playerAttackTrigger;
    private Rigidbody2D rb;
    private bool isAttack;
    private float timeAttackElapsed;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        playerAttackTrigger = this.transform.GetChild(1).GetComponent<BoxCollider2D>();
        animator = this.GetComponent<Animator>();
	}
	
	
	void Update () {
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRunning", true);
            rb.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isRunning", true);
            rb.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            animator.SetBool("isRunning", false);
            rb.velocity = new Vector2(0, 0);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            playerAttackTrigger.enabled = true;
            isAttack = true;
            animator.SetTrigger("kick");
            if (!speechBubble.IsEnable)
            {
                speechBubble.EnableSpeech();
            }
        }

        if (isAttack)
        {
            timeAttackElapsed += Time.deltaTime;
            if (timeAttackElapsed >= 0.15f)
            {
                timeAttackElapsed = 0;
                isAttack = false;
                playerAttackTrigger.enabled = false;

            }
        }

    }
}
