using UnityEngine;

// Stuff that could be added to improve this:
// Zoom amount based on size of object, I.e. so zooms in more on smaller objects and vice versa
// Camera pans over to object being clicked on rather than it being instant
[RequireComponent(typeof(BoxCollider2D))]
public class zoomInInteractable : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 originalCameraPosition;
    private float originalZoom;
    private float zoomFactor = 0.4f;

    void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera != null && mainCamera.orthographic)
        {
            originalCameraPosition = mainCamera.transform.position;
            originalZoom = mainCamera.orthographicSize;
        }
    }

    private void OnMouseDown()
    {
        CenterCameraOnObject();
        ZoomIn();
    }

    private void OnMouseUp()
    {
        ResetCameraPosition();
        ResetZoom();
    }

    private void CenterCameraOnObject()
    {
        if (mainCamera == null) return;

        Vector3 objectPosition = transform.position;
        mainCamera.transform.position = new Vector3(objectPosition.x, objectPosition.y, originalCameraPosition.z);
    }

    private void ZoomIn()
    {
        if (mainCamera == null) return;

        mainCamera.orthographicSize = Mathf.Max(0.1f, originalZoom * zoomFactor);
    }

    private void ResetCameraPosition()
    {
        if (mainCamera == null) return;

        mainCamera.transform.position = originalCameraPosition;
    }

    private void ResetZoom()
    {
        if (mainCamera == null) return;

        mainCamera.orthographicSize = originalZoom;
    }
}
