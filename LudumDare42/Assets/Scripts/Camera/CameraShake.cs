using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public static CameraShake Instance;
    public float amplitude;
    public bool isContinueShake;

    public Transform initPos;
    private bool isShake;

    void Start () {
        Instance = this;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(initPos.position);
        if (isContinueShake)
        {
            Shake(initPos.position, amplitude);
        }
        this.transform.position = new Vector3(this.transform.position.x, 0 , this.transform.position.z);
	}

    public void ShakeOne(float amplitude, float duration)
    {
        if (!isShake)
        {
            StartCoroutine(StartShake(amplitude, duration));
        }
    }

    public IEnumerator StartShake(float amplitude, float duration)
    {
        isShake = true;
        float elapsed = 0f;
        Vector3 position = Vector3.zero;
        while (elapsed < duration)
        {
            position.x = initPos.position.x + PositiveNegative() * Random.Range(0f, 1f) * amplitude;
            position.y = initPos.position.y + PositiveNegative() * Random.Range(0f, 1f) * amplitude;
            
            elapsed += Time.deltaTime;
            this.transform.position = new Vector3(position.x, position.y, -10);

            yield return null;
        }
        this.transform.position = new Vector3(initPos.position.x, initPos.position.y, -10);
        isShake = false;
    }

    public void Shake(Vector2 initPosition, float amplitude)
    {
        //Debug.Log("initial: " + initPosition);
        Vector2 position = new Vector2(0,0);
        position.x = initPosition.x + PositiveNegative() * Random.Range(0f, 1f) * amplitude;
        position.y = initPosition.y + PositiveNegative() * Random.Range(0f, 1f) * amplitude;
        //Debug.Log("after: " + position);
        this.transform.position = new Vector3(position.x, position.y, -10);
    }

    private int PositiveNegative()
    {
        return Random.Range(0f, 1f) > 0.5 ? 1 : -1;
    }
}
