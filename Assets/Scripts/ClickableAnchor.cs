using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableAnchor : MonoBehaviour
{
    public static GameObject clickedObject;

    public void Start() {
        Physics2D.queriesHitTriggers = true;
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked!");
        // clickedObject = transform.parent.gameObject;
        clickedObject = gameObject;
        Debug.Log("Clicked: " + clickedObject);
    }
    void OnMouseUp()
    {
        Debug.Log("Mouse released on: " + clickedObject);
        clickedObject = null; // Reset the clicked object to null
    }
}
