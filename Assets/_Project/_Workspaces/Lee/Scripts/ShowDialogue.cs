using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowDialogue : MonoBehaviour
{
    public string[] dialogues;
    private int _dialogueIndex;
    public TextMeshProUGUI textDisplay;
    
    private void DisplayTextByIndex(int index)
    {
        if (index >= 0 && index < dialogues.Length)
        {
            textDisplay.text = dialogues[index];
        }
        else
        {
            Debug.LogWarning("Index out of range");
            textDisplay.text = "Text not found";
        }
    }
    
    public void ShowText()
    {
        DisplayTextByIndex(_dialogueIndex );
        if (_dialogueIndex < dialogues.Length - 1) {
            _dialogueIndex++;
        }
    }
}
