using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Switch : MonoBehaviour {

    public Train train;
    private TextMeshPro displayText;

    public Direction direction;

    void Start()
    {
        displayText = this.GetComponentInChildren<TextMeshPro>();
        displayText.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    { 
        ChangeCompartment(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeCompartment(collision);
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            displayText.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void ChangeCompartment(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            displayText.GetComponent<MeshRenderer>().enabled = true;
            train.ChangeSwitchDirection(direction);
            if (Input.GetKeyDown(KeyCode.E))
            {
                //train.ChangeCompartment(direction);
            }
        }
    }
}
