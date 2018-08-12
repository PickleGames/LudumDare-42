using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    public float speed = 5;
    private Rigidbody2D rb;
    private bool isFly;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (isFly)
        {
            transform.Translate(new Vector2(-0.10f, 0));
        }
    }

    public void FlyAway()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        isFly = true;
    }
}
