using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays information about the object when it is clicked on
/// Intended to be attached to object being clicked
/// Requires a BoxCollider2D component to detect clicks on the object
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public class ShowInteractableInfo : MonoBehaviour
{
    public Text dialogueText;

    private BoxCollider2D objectCollider;

    void Start()
    {
        objectCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (objectCollider != null && objectCollider.OverlapPoint(mousePosition))
            {
                Debug.Log("Clicked on " + gameObject.name);
                dialogueText.text = gameObject.name;
            }
        }
    }
}
