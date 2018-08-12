using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : MonoBehaviour {

    public float speed;
    private Camera cam;
    private SpriteRenderer sr;
    private float spriteWidth;
    private Vector2 ogPos;

    private float camHorizontalExtent;
    private float edgePositionLeft;
    private float edgePositionRight;
    // Use this for initialization
    void Start () {
        cam = Camera.main;
        sr = GetComponent<SpriteRenderer>();
        spriteWidth = this.transform.localScale.x * sr.sprite.bounds.size.x;
        ogPos = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (sr.enabled)
        {
            Move();
        }
        

        // calculates the cameras extent (half the width) of what the camera can see in world coordinates
        camHorizontalExtent = cam.orthographicSize * Screen.width / Screen.height;
        // calculate the x position where tha camera can seee the edge of the sprite
        edgePositionRight = (this.transform.position.x + spriteWidth / 2) - camHorizontalExtent;
        edgePositionLeft = (this.transform.position.x - spriteWidth / 2) + camHorizontalExtent;
    }

    public bool InCenter()
    {
        return this.transform.position.x < cam.transform.position.x;
    }

    public bool OffScreen()
    { 
        return edgePositionRight + spriteWidth/2 <= cam.transform.position.x;
    }

    public void Move()
    {
        this.transform.Translate(-speed, 0, 0);
    }

    public void BeGone()
    {
        sr.enabled = false;
    }

    public void ComeBack()
    {
        sr.enabled = true;
        Debug.Log("Turn on sprite!!");
        Debug.Log(sr.enabled);
        Debug.Log(sr);
    }
  
    public void ResetTunnel()
    {
        transform.position = ogPos;
        ComeBack();
        sr.enabled = true;
       
    }
}
