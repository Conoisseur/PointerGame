using TMPro;
using UnityEngine;

/// Displays information about the object when it is clicked on.
/// Intended to be attached to the object being clicked.
/// Requires a BoxCollider2D component to detect clicks on the object.
[RequireComponent(typeof(BoxCollider2D))]
public class ShowInteractableInfo : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    private void OnMouseDown()
    {
        if (dialogueText != null)
        {
            Debug.Log("Clicked on " + gameObject.name);
            dialogueText.text = gameObject.name;
        }
    }
}
