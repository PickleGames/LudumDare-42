using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AI : MonoBehaviour {

    public bool IsFly { get; private set; }
    public TrainCart trainCart;
    public int health;
    public bool IsDead { get; private set; }
    public bool isJustAttack;
    public AudioClip[] clips;

    private float timeElapsedAttack;
    private float timeElapsedColor;
    private bool isColorChanged;

    private TextMeshPro textMoney;
    private float timeMoney;
    private float timeMoneyDis;
    private bool isMoneyEnable;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        sprite.enabled = false;
        health = 3;
        textMoney = this.GetComponentInChildren<TextMeshPro>();
        textMoney.enabled = false;
    }

    public void EnableSpeech()
    {
        isMoneyEnable = true;
        textMoney.enabled = true;
    }

    public void DisableSpeech()
    {
        textMoney.enabled = false;
    }

    float delay = 2;
    void Update()
    {
        if (sprite.enabled)
        {
            timeMoney += Time.deltaTime;
            if (timeMoney > delay)
            {
                timeMoney = 0;
                EnableSpeech();
                delay = Random.Range(1f, 3f);
            }
            if (isMoneyEnable)
            {
                timeMoneyDis += Time.deltaTime;
                if (timeMoneyDis >= 2)
                {
                    isMoneyEnable = false;
                    timeMoneyDis = 0;
                    DisableSpeech();
                }
            }
        }else
        {
            DisableSpeech();
        }
        


        if (IsFly)
        {
            transform.Translate(new Vector2(-.35f, 0));
            transform.RotateAround(transform.position, Vector3.down, -5);
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
        AudioSource scream = this.GetComponent<AudioSource>();
        scream.clip = clips[0];
        scream.volume = 0.25f;
        scream.pitch = Random.Range(.65f, 1f);
        if (!scream.isPlaying)
        {
            scream.Play();
        }

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
