using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    private Rigidbody2D rb;
    public bool IsFly { get; private set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (IsFly)
        {
            transform.Translate(new Vector2(-0.25f, 0));
        }
    }

    public void FlyAway()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        IsFly = true;
    }
}
