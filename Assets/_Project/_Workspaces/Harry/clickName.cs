using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickName : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Get the world position of the mouse click
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Check if the mouse is over a 2D collider
            Collider2D hit = Physics2D.OverlapPoint(mousePosition);

            // If a collider is hit, print the name of the object
            if (hit != null)
            {
                Debug.Log("Object clicked: " + hit.transform.name);
            }
            else
            {
                Debug.Log("Nothing pressed");
            }
        }
    }
}
