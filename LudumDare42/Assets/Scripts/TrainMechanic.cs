using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TrainMechanic : MonoBehaviour {





    //FOR TESTING ONLY
    void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log("SEE IN");
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        Debug.Log("Stop Seeing Inside");
    }
}
