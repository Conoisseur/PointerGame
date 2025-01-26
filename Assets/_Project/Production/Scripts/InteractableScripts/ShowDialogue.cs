using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowDialogue : MonoBehaviour
{
    public DialogueSO dialogueSo;
    private DialogueBoxWriter _dialogueBoxWriter;

    //public TextMeshProUGUI textDisplay;

    private void Start()
    {
        _dialogueBoxWriter = FindObjectOfType<DialogueBoxWriter>();

        if (_dialogueBoxWriter == null)
        {
            Debug.LogError("Dialogue box component not found on Dialogue Box in Start!");
        }
        // Debug.Log(_dialogueBoxWriter);
    }

    public void ShowText()
    {
        string[] dialogues = dialogueSo.dialogues;
        int index = dialogueSo.dialogueIndex;
        if (_dialogueBoxWriter == null){
            _dialogueBoxWriter = FindObjectOfType<DialogueBoxWriter>();
        }
        
        if (index >= 0 && index < dialogues.Length)
        {
            //textDisplay.text = dialogues[index];
            _dialogueBoxWriter.type(dialogues[index]);
        }
        
        if (index < dialogues.Length - 1) {
            dialogueSo.dialogueIndex++;
        }
        else
        {
            dialogueSo.dialogueIndex = 0;
        }
    }

    public virtual void OnMouseDown()
    {
        ShowText();
    }

}


