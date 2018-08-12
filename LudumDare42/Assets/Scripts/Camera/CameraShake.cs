using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public Camera camera;
    public float amplitude;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 initPos = camera.transform.position;
        Shake(initPos, amplitude);
        //camera.transform.position = initPos;
	}

    public void Shake(Vector2 initPosition, float amplitude)
    {
        //Debug.Log("initial: " + initPosition);
        Vector2 position = new Vector2(0,0);
        position.x = initPosition.x + PositiveNegative() * Random.Range(0f, 1f) * amplitude;
        position.y = initPosition.y + PositiveNegative() * Random.Range(0f, 1f) * amplitude;
        //Debug.Log("after: " + position);
        camera.transform.position = new Vector3(position.x, position.y, -10);
    }

    private int PositiveNegative()
    {
        return Random.Range(0f, 1f) > 0.5 ? 1 : -1;
    }
}
