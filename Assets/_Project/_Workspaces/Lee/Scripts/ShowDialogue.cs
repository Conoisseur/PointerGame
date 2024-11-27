using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowDialogue : MonoBehaviour
{
    public DialogueSO dialogueSo;
    
    public TextMeshProUGUI textDisplay;
    
    public void ShowText()
    {
        string[] dialogues = dialogueSo.dialogues;
        int index = dialogueSo.dialogueIndex;
        
        Debug.Log(dialogues[index]);
        Debug.Log(index);
        if (index >= 0 && index < dialogues.Length)
        {
            textDisplay.text = dialogues[index];
        }
        
        if (index < dialogues.Length - 1) {
            dialogueSo.dialogueIndex++;
        }
        else
        {
            dialogueSo.dialogueIndex = 0;
        }
    }

    public void OnMouseDown()
    {
        ShowText();
    }

}


