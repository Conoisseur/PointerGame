using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Color hoverColor = Color.yellow; // Tint color when hovering
    private Color originalColor; // Store the original color
    private Renderer objectRenderer;

    void Start()
    {
        // Get the Renderer component and store the original color
        objectRenderer = GetComponent<SpriteRenderer>();
        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color;
        }
        
    }

    void OnMouseEnter()
    {
        // Change the material color to the hover color
        if (objectRenderer != null)
        {
            objectRenderer.material.color = hoverColor;
        }
    }

    void OnMouseExit()
    {
        // Reset the material color to the original color
        if (objectRenderer != null)
        {
            objectRenderer.material.color = originalColor;
        }
    }
}
