using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CameraShake))]

public class PlayerAttackCollider : MonoBehaviour {

    public CameraShake camShake;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AI"))
        {
            Debug.Log("aiiii");

            transform.parent.GetComponent<AudioSource>().Play();

            AI ai = collision.transform.GetComponent<AI>();
            AudioSource oof = collision.transform.GetComponent<AudioSource>();
            if (!oof.isPlaying)
            {
                oof.Play();
            }

            ai.DealDamage();
            camShake.ShakeOne(0.25f, .25f);

        }
    }
}
