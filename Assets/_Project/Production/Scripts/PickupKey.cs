using UnityEngine;

public class PickupKey : MonoBehaviour
{
    void OnMouseDown()
    {
        if (playerInventory.Instance != null)
        {
            playerInventory.Instance.playerHasKey = true;
            Debug.Log("Key picked up!");
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("playerInventory instance is not found!");
        }
    }
}
