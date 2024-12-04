using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Color hoverColor = Color.yellow; // Tint color when hovering
    private Color _originalColor; // Store the original color
    private Renderer _objectRenderer;

    void Start()
    {
        // Get the Renderer component and store the original color
        _objectRenderer = GetComponent<SpriteRenderer>();
        if (_objectRenderer != null)
        {
            _originalColor = _objectRenderer.material.color;
        }
        
    }

    void OnMouseEnter()
    {
        // Change the material color to the hover color
        if (_objectRenderer != null)
        {
            _objectRenderer.material.color = hoverColor;
        }
    }

    void OnMouseExit()
    {
        // Reset the material color to the original color
        if (_objectRenderer != null)
        {
            _objectRenderer.material.color = _originalColor;
        }
    }
}
