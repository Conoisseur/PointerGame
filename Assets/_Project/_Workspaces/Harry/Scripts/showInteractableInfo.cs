using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ShowInteractableInfo : MonoBehaviour
{
    private DialogueBoxWriter _typingEffect;  

    private void Start()
    {
        _typingEffect = FindObjectOfType<DialogueBoxWriter>();

        if (_typingEffect == null)
        {
            Debug.LogError("TypingEffect component not found on Dialogue Box!");
        }
    }

    private void OnMouseDown()
    {
        if (_typingEffect != null)
        {
            Debug.Log("Clicked on " + gameObject.name);
            _typingEffect.type(gameObject.name);  
        }
    }
}
