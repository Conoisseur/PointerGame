using System;
using UnityEngine;
using UnityEngine.Serialization;

/**
 * Attach to the door. Displays dialogueSO if you don't have the key
 * and displays unlockedDialogueSO when the key is picked up.
 * SetHasKey() method is used to toggle whether the key is picked up.
 */
public class Door : ShowDialogue
{
    public DialogueSO unlockedDialogueSo;
    private bool _hasKey = false;

    public void SetHasKey()
    {
        _hasKey = true;
    }

    public override void OnMouseDown()
    {
        if (_hasKey)
        {
            dialogueSo = unlockedDialogueSo;
        }
        ShowText();
    }
}