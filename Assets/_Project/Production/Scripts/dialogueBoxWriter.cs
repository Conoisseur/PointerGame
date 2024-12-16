using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueBoxWriter : MonoBehaviour
    // Attach as component to dialogue box
    // Manages text that is requested to be put in dialogue box
{
    private TextMeshProUGUI dialogueText;
    private float typingSpeed = 0.1f;    

    private void Awake()
    {

        dialogueText = GetComponent<TextMeshProUGUI>();

        if (dialogueText == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on this GameObject.");
        }
    }

    public void type(string message)
    {
        // TODO stops all coroutines to ensure only one coroutine typing at a time
        // If coroutine used in another part of program, could interfere so probably need to change lol
        StopAllCoroutines();

        StartCoroutine(TypeText(message)); 
    }

    private IEnumerator TypeText(string message)
    {
        dialogueText.text = "";

        foreach (char letter in message)
        {
            dialogueText.text += letter;  
            yield return new WaitForSeconds(typingSpeed);  
        }
    }
}
