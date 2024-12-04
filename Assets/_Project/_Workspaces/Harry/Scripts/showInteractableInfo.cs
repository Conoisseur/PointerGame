using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ShowInteractableInfo : MonoBehaviour
{
    private DialogueBoxWriter _dialogueBoxWriter;  

    private void Start()
    {
        _dialogueBoxWriter = FindObjectOfType<DialogueBoxWriter>();

        if (_dialogueBoxWriter == null)
        {
            Debug.LogError("Dialogue box component not found on Dialogue Box!");
        }
    }

    private void OnMouseDown()
    {
        if (_dialogueBoxWriter != null)
        {
            Debug.Log("Clicked on " + gameObject.name);
            _dialogueBoxWriter.type(gameObject.name);  
        }
    }
}
