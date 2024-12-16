using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Lock : MonoBehaviour
{
    public DialogueSO noKeyDialogueSO; 
    public DialogueSO hasKeyDialogueSO; 
    public string winMessage = "You Win!"; 
    public float delayBeforeQuit = 2f;

    private DialogueBoxWriter _dialogueBoxWriter;

    private void Start()
    {
        // Find the DialogueBoxWriter in the scene
        _dialogueBoxWriter = FindObjectOfType<DialogueBoxWriter>();

        if (_dialogueBoxWriter == null)
        {
            Debug.LogError("DialogueBoxWriter not found in the scene!");
        }
    }

    private void ShowText(DialogueSO dialogueSo)
    {
        if (_dialogueBoxWriter == null)
        {
            _dialogueBoxWriter = FindObjectOfType<DialogueBoxWriter>();
        }

        if (dialogueSo != null)
        {
            string[] dialogues = dialogueSo.dialogues;
            int index = dialogueSo.dialogueIndex;

            if (index >= 0 && index < dialogues.Length)
            {
                _dialogueBoxWriter.type(dialogues[index]); // Trigger typing effect
            }

            // Update dialogue index or reset
            if (index < dialogues.Length - 1)
            {
                dialogueSo.dialogueIndex++;
            }
            else
            {
                dialogueSo.dialogueIndex = 0;
            }
        }
        else
        {
            Debug.LogError("DialogueSO is missing!");
        }
    }

    private void OnMouseDown()
    {
        if (playerInventory.Instance != null && playerInventory.Instance.playerHasKey)
        {
            UseKey();
        }
        else
        {
            ShowText(noKeyDialogueSO);
        }
    }

    private void UseKey()
    {
        // Display the winning message
        if (_dialogueBoxWriter != null)
        {
            _dialogueBoxWriter.type(winMessage);
        }
        else
        {
            Debug.Log(winMessage); // Fallback for debugging
        }

        // End the game after a delay
        StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        Renderer lockRenderer = GetComponent<Renderer>();
        if (lockRenderer != null)
        {
            lockRenderer.enabled = false; 
        }
        else
        {
            Debug.LogWarning("Renderer component not found on the lock object.");
        }

        yield return new WaitForSeconds(delayBeforeQuit);

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; 
        #else
                Application.Quit(); 
        #endif
    }
}
