using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))] // creates a spriterenderer if one is not attached

public class Tiling : MonoBehaviour
{

    public int offsetX = 2;         // the offset so that clones load before getting into cam view

    // used to check if we need to instantiate clones
    public bool hasARightClone = false;
    public bool hasALeftClone = false;

    public bool reverseScale = false;   // used if the object is not tilable

    public float moveSpeed;
    public bool station;

    private SpriteRenderer sr;
    private float spriteWidth = 0f;
    private Camera cam;
    private Transform myTransform;

    public Sprite trainStation;

    private void Awake()
    {
        cam = Camera.main;
        myTransform = transform;
    }

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        spriteWidth = this.transform.parent.localScale.x * sr.sprite.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        // move this mudafuka 
        MoveClone();

        // calculates the cameras extent (half the width) of what the camera can see in world coordinates
        float camHorizontalExtent = cam.orthographicSize * Screen.width / Screen.height;

        // calculate the x position where tha camera can seee the edge of the sprite
        float edgePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtent;
        float edgePositionLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtent;

        // does it still need clones? If not do nothing
        if (!hasALeftClone || !hasARightClone)
        {
           
            // checking if edge of sprite is visible and instantiate new clone if possible
            if (cam.transform.position.x >= edgePositionRight - offsetX && !hasARightClone)
            {
                if (station)
                {
                    MakeNewClone(1, trainStation);                 
                }
                else
                {
                    MakeNewClone(1);
                }
                hasARightClone = true;
            }
            else if (cam.transform.position.x <= edgePositionLeft + offsetX && !hasALeftClone)
            {
                if (station)
                {
                    MakeNewClone(-1, trainStation);                 
                }
                else
                {
                    MakeNewClone(-1);
                }
                hasALeftClone = true;
            }

        }

        // check if clone is 'offscreen' (to the left) and delete
        if (edgePositionRight + spriteWidth / 2 <= cam.transform.position.x)
        {
            hasALeftClone = false;
            Destroy(this.gameObject);
        }

        if(station && edgePositionLeft > cam.transform.position.x + spriteWidth)
        {
            sr.sprite = trainStation;
            spriteWidth = this.transform.parent.localScale.x * sr.sprite.bounds.size.x;
        }
    }

    // function that instantiates a new clone on the side required
    void MakeNewClone(int direction)
    {
        // calculating the position of the clone
        Vector3 newPosition =
            new Vector3(myTransform.position.x + spriteWidth * direction, myTransform.position.y, myTransform.position.z);

        // instantiating new clone and storing it in a variable
        Transform newClone = (Transform)Instantiate(myTransform, newPosition, myTransform.rotation, myTransform.parent);

        // if not tilable reverse the x size of object to smooth out the seam
        if (reverseScale)
        {
            newClone.localScale = new Vector3(newClone.localScale.x * -1, newClone.localScale.y, newClone.localScale.z);
        }

         //newClone.parent = myTransform.parent;

        if (direction > 0)
        {
            // if clone is on the right, tell the clone it has a instance on the left 
            // (to prevent instantiates over existing clones)
            newClone.GetComponent<Tiling>().hasALeftClone = true;
        }
        else
        {
            newClone.GetComponent<Tiling>().hasARightClone = true;
        }
    }

    // make a new clone with a new sprite
    void MakeNewClone(int direction, Sprite sprite)
    { 
        Vector3 newPosition =
            new Vector3(myTransform.position.x + spriteWidth * direction, myTransform.position.y, myTransform.position.z);

        Transform newClone = (Transform)Instantiate(myTransform, newPosition, myTransform.rotation, myTransform.parent);
        newClone.GetComponent<SpriteRenderer>().sprite = sprite;

        if (reverseScale)
        {
            newClone.localScale = new Vector3(newClone.localScale.x * -1, newClone.localScale.y, newClone.localScale.z);
        }

        if (direction > 0)
        {
            newClone.GetComponent<Tiling>().hasALeftClone = true;
        }
        else
        {
            newClone.GetComponent<Tiling>().hasARightClone = true;
        }

    }

    // move clone to the left
    private void MoveClone() 
    {
        this.transform.Translate(-moveSpeed, 0, 0); 
    }

}