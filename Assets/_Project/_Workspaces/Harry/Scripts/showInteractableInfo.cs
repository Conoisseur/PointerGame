using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ShowInteractableInfo : MonoBehaviour
{
    private DialogueBoxWriter typingEffect;  

    private void Start()
    {
        GameObject dialogueTextObject = GameObject.FindWithTag("Dialogue Box");

        if (dialogueTextObject != null)
        {
            typingEffect = dialogueTextObject.GetComponent<DialogueBoxWriter>();
        }

        if (typingEffect == null)
        {
            Debug.LogError("TypingEffect component not found on Dialogue Box!");
        }
    }

    private void OnMouseDown()
    {
        if (typingEffect != null)
        {
            Debug.Log("Clicked on " + gameObject.name);
            typingEffect.type(gameObject.name);  
        }
    }
}
