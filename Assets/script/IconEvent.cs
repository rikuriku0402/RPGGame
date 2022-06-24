using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IconEvent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckEvent(collision);   
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        CheckEvent(collision);
    }
    void CheckEvent(Collider2D collider)
    {
        if (collider.tag == "Icon")
        {
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                EventSystem.current.SetSelectedGameObject(gameObject);
            }
            if (Input.GetButtonDown("Submit")){}
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Icon")
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}
