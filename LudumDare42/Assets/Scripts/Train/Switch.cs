using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public Train train;

    public Direction direction;

    private void OnTriggerStay2D(Collider2D collision)
    {
        ChangeCompartment(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeCompartment(collision);
    }

    private void ChangeCompartment(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                train.ChangeCompartment(direction);
            }
        }
    }
}
