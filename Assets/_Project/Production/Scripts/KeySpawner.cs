using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public GameObject keyPrefab; // Reference to the key prefab
    public Vector3 spawnPosition; // Position where the key should spawn
    public Quaternion spawnRotation = Quaternion.identity; // Rotation of the spawned key (default is no rotation)

    private DialogueBoxWriter _dialogueBoxWriter; // Reference to the DialogueBoxWriter

    private void Start()
    {
        _dialogueBoxWriter = FindObjectOfType<DialogueBoxWriter>();
        if (_dialogueBoxWriter == null)
        {
            Debug.LogError("DialogueBoxWriter component not found in the scene!");
        }
    }

    public void SpawnKey()
    {
        if (keyPrefab != null)
        {
            Instantiate(keyPrefab, spawnPosition, spawnRotation);
            Debug.Log("Key spawned at position: " + spawnPosition);

            ShowChestOpenedMessage();
        }
        else
        {
            Debug.LogError("Key prefab is not assigned!");
        }
    }

    public void ShowChestOpenedMessage()
    {
        if (_dialogueBoxWriter != null)
        {
            _dialogueBoxWriter.type("The chest opened!");
        }
        else
        {
            Debug.LogError("DialogueBoxWriter is not assigned or found in the scene!");
        }
    }
}
