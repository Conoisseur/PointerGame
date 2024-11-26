using System.Collections;
using TMPro;
using UnityEngine;

public class TypingEffect : MonoBehaviour
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
