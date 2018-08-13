using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    public bool IsFly { get; private set; }
    public TrainCart trainCart;
    public int health;
    public bool IsDead { get; private set; }
    public bool isJustAttack;

    private float timeElapsedAttack;
    private float timeElapsedColor;
    private bool isColorChanged;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        sr.enabled = false;
        health = 3;
    }


    void Update()
    {
        if (IsFly)
        {
            transform.Translate(new Vector2(-.35f, 0));
            transform.RotateAround(transform.position, Vector3.up, 5);
        }
        if(health <= 0)
        {
            IsDead = true;
        }

        if (isJustAttack)
        {
            timeElapsedAttack += Time.deltaTime;
            if (timeElapsedAttack >= 1)
            {
                timeElapsedAttack = 0;
                isJustAttack = false;
            }
        }

        if(isColorChanged)
        {
            timeElapsedColor += Time.deltaTime;
            if(timeElapsedColor >= .25f)
            {
                timeElapsedColor = 0;
                isColorChanged = false;
                ResetColor();
            }
        }

    }

    public void FlyAway()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        IsFly = true;
        trainCart.RemovePeople(this.gameObject);
    }

    public void DealDamage()
    {
        health--;
        isJustAttack = true;
        if(health <= 0)
        {
            FlyAway();
        }
        ChangeColor();
    }

    private void ChangeColor()
    {
        SpriteRenderer sr = this.GetComponentInChildren<SpriteRenderer>();
        sr.color = new Color(1f, 0, 0, .7f);
        isColorChanged = true;
    }

    private void ResetColor()
    {
        SpriteRenderer sr = this.GetComponentInChildren<SpriteRenderer>();
        sr.color = new Color(1f, 1f, 1f, 1f);
    }

}
