using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject followObject;
    public Vector2 offset;
    public Vector2 speed;

    private Vector2 followPosition;

	void Start () {
        followPosition = followObject.transform.position;
	}
	
    /**
     * Lerp to object
     **/
	void Update () {
        Vector2 position = this.transform.position;
        followPosition = followObject.transform.position;
        position.x += (followPosition.x - position.x) * speed.x;
        position.y += (followPosition.y - position.y) * speed.y;
        this.transform.position = new Vector3(position.x, position.y + offset.y, -10);
	}
}
