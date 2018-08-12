using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 5;

    private Rigidbody2D rb;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	
	void Update () {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
        

    }
}
