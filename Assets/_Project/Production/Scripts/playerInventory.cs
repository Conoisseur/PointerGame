using UnityEngine;

public class playerInventory : MonoBehaviour
{
    public static playerInventory Instance { get; private set; } // Singleton instance

    public bool playerHasKey = false;

    private void Awake()
    {
        // Ensure only one instance of playerInventory exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make the inventory persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }
}
