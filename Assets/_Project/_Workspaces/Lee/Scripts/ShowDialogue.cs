using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowDialogue : MonoBehaviour
{
    public DialogueSO dialogueSo;
    
    public TextMeshProUGUI textDisplay;
    private int _index = 0;

    void ShowText()
    {
        string[] dialogues = dialogueSo.dialogues;
        
        Debug.Log(dialogues[_index]);
        Debug.Log(_index);
        if (_index >= 0 && _index < dialogues.Length)
        {
            textDisplay.text = dialogues[_index];
        }
        
        if (_index < dialogues.Length - 1) {
            _index++;
        }
        else
        {
            _index = 0;
        }
    }

    void OnMouseDown()
    {
        ShowText();
    }
}
