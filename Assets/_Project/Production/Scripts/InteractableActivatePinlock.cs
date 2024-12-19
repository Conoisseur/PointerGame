using UnityEngine;

public class InteractableActivatePinLock : MonoBehaviour
{
    public string canvasName = "Canvas"; // Name of the canvas containing the Combination Lock
    public string pinLockName = "Combination Lock"; // Name of the Combination Lock object in the canvas
    public string interactMessage = "Combination Lock activated!"; // Optional message for debugging

    private GameObject _pinLockObject; // Reference to the Combination Lock

    private void Start()
    {
        // Find the canvas in the scene
        GameObject canvasObject = GameObject.Find(canvasName);
        if (canvasObject == null)
        {
            Debug.LogError($"Could not find a Canvas named '{canvasName}' in the scene!");
            return;
        }

        // Search for the Combination Lock inside the canvas
        Transform pinLockTransform = canvasObject.transform.Find(pinLockName);
        if (pinLockTransform != null)
        {
            _pinLockObject = pinLockTransform.gameObject;
            _pinLockObject.SetActive(false); // Ensure it's deactivated at the start
        }
        else
        {
            Debug.LogError($"Could not find an object named '{pinLockName}' in the canvas '{canvasName}'!");
        }

        // Subscribe to the event in all zoomInInteractable instances in the scene
        var zoomInInteractableScripts = FindObjectsOfType<zoomInInteractable>();
        foreach (var script in zoomInInteractableScripts)
        {
            script.onZoomOutEvent.AddListener(DeactivatePinLock);
        }
    }

    private void OnMouseDown()
    {
        if (_pinLockObject != null)
        {
            _pinLockObject.SetActive(true); // Activate the Combination Lock
            Debug.Log(interactMessage);
        }
        else
        {
            Debug.LogError("Combination Lock object is not set or could not be found!");
        }
    }

    private void DeactivatePinLock()
    {
        if (_pinLockObject != null)
        {
            _pinLockObject.SetActive(false); // Deactivate the Combination Lock
            Debug.Log("Combination Lock deactivated!");
        }
    }
}
