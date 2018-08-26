using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {

    public float speed = 5;
    public SpeechBubble speechBubble;
    public JoystickController joystick;

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

        if (Mathf.Abs(rb.velocity.y) > 5)
        {
            Debug.Log("eyyyyy u lose");
            Stats.instance.UpdateStat();
            SceneManager.LoadScene("LOST");
        }

        if(rb.velocity.x != 0)
        {
            animator.SetBool("isRunning", true);
            if(rb.velocity.x > 0)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector2(-1, 1);
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        { 
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
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

        UpdateJoystickMovement();
    }

    public void Attack()
    {
        playerAttackTrigger.enabled = true;
        isAttack = true;
        animator.SetTrigger("kick");
        if (!speechBubble.IsEnable)
        {
            speechBubble.EnableSpeech();
        }
    }

    private void UpdateJoystickMovement()
    {
        if(joystick != null)
        {
            float x = joystick.X * speed;
            float y = joystick.Y;
            rb.velocity = new Vector2(x, rb.velocity.y);
        }
    }
}
