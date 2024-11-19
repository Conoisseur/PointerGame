using System.Collections;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class zoomInInteractable : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 originalCameraPosition;
    private float originalZoom;
    private float zoomFactor = 0.4f;
    private float zoomDuration = 0.2f; 

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
        StartCoroutine(ZoomInCoroutine());
    }

    private void OnMouseUp()
    {
        StartCoroutine(ResetCameraCoroutine());
    }

    private IEnumerator ZoomInCoroutine()
    {
        float elapsedTime = 0f;
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, originalCameraPosition.z);
        float targetZoom = Mathf.Max(0.1f, originalZoom * zoomFactor);

        while (elapsedTime < zoomDuration)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, elapsedTime / zoomDuration);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetZoom, elapsedTime / zoomDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = targetPosition;
        mainCamera.orthographicSize = targetZoom;
    }

    private IEnumerator ResetCameraCoroutine()
    {
        float elapsedTime = 0f;
        Vector3 targetPosition = originalCameraPosition;
        float targetZoom = originalZoom;

        while (elapsedTime < zoomDuration)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, elapsedTime / zoomDuration);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetZoom, elapsedTime / zoomDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = targetPosition;
        mainCamera.orthographicSize = targetZoom;
    }
}
