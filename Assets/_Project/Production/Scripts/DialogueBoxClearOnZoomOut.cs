using UnityEngine;
using UnityEngine.SceneManagement;

// Attached to dialogue box
// Subscribes to zoom out event and whenever zooming out we set the dialogue box to blank
public class DialogueBoxClearOnZoomOut : MonoBehaviour
{
    private DialogueBoxWriter _dialogueBoxWriter;

    void Start()
    {
        _dialogueBoxWriter = FindObjectOfType<DialogueBoxWriter>();
        if (_dialogueBoxWriter == null)
        {
            Debug.LogError("DialogueBoxWriter component not found in the scene!");
        }

        SubscribeToZoomOutEvents();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SubscribeToZoomOutEvents();
    }

    private void SubscribeToZoomOutEvents()
    {
        var zoomInInteractableScripts = FindObjectsOfType<zoomInInteractable>();
        foreach (var script in zoomInInteractableScripts)
        {
            script.onZoomOutEvent.RemoveListener(ClearDialogueBox); // Avoid duplicate subscriptions
            script.onZoomOutEvent.AddListener(ClearDialogueBox);
        }
    }

    private void ClearDialogueBox()
    {
        if (_dialogueBoxWriter != null)
        {
            Debug.Log("Clearing dialogue box.");
            _dialogueBoxWriter.type("");
        }
        else
        {
            Debug.LogError("DialogueBoxWriter is null. Cannot clear dialogue box.");
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        var zoomInInteractableScripts = FindObjectsOfType<zoomInInteractable>();
        foreach (var script in zoomInInteractableScripts)
        {
            script.onZoomOutEvent.RemoveListener(ClearDialogueBox);
        }
    }
}
