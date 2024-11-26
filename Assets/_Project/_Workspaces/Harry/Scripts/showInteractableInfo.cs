using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ShowInteractableInfo : MonoBehaviour
{
    private TextMeshProUGUI dialogueText;
    private void Start()
    {
        GameObject dialogueTextObject = GameObject.FindWithTag("Dialogue Box");

        if (dialogueTextObject != null)
        {
            dialogueText = dialogueTextObject.GetComponent<TextMeshProUGUI>();
        }

        if (dialogueText == null)
        {
            Debug.LogError("Dialogue Box not found!");
        }
    }


    private void OnMouseDown()
    {
        if (dialogueText != null)
        {
            Debug.Log("Clicked on " + gameObject.name);
            dialogueText.text = gameObject.name;
        }
    }
}
