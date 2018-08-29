using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CameraShake))]

public class PlayerAttackCollider : MonoBehaviour {

    public CameraShake camShake;
    public int smackedCount;

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
            smackedCount++;
            transform.parent.GetComponent<AudioSource>().Play();

            AI ai = collision.transform.GetComponent<AI>();
            AudioSource oof = collision.transform.GetComponent<AudioSource>();
            if (!oof.isPlaying)
            {
                oof.volume = 0.5f;
                oof.pitch = 1;
                oof.Play();
            }

            ai.DealDamage();
            camShake.ShakeOne(0.10f, .25f);

        }
    }
}
