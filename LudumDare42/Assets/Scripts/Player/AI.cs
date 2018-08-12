using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    private Rigidbody2D rb;
    public bool IsFly { get; private set; }
    public TrainCart trainCart;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        sr.enabled = false;
    }


    void Update()
    {
        if (IsFly)
        {
            transform.Translate(new Vector2(-0.25f, 0));
            transform.Rotate(new Vector3(0, 0, 25));
        }
    }

    public void FlyAway()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        IsFly = true;
        trainCart.RemovePeople(this.gameObject);
    }
}
