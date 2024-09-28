using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public void clickButton()
    {
        if(button != null)
            button.ClickButton();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ButtonTriggerCollider"))
        {
            button = collision.GetComponent<ButtonAction>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("ButtonTriggerCollider"))
        {
            button = null;
        }
    }

    private ButtonAction button;
}
