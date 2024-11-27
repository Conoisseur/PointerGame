using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class zoomInInteractable : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 originalCameraPosition;
    private float originalZoom;
    private float zoomFactor = 0.4f;
    private float zoomDuration = 0.5f;
    private bool zoomEnabled = false;

    private GameObject resetButton;

    void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera != null && mainCamera.orthographic)
        {
            originalCameraPosition = mainCamera.transform.position;
            originalZoom = mainCamera.orthographicSize;
        }

        CreateResetButton();
    }

    private void OnDestroy()
    {
        if (resetButton != null)
        {
            Destroy(resetButton);
        }
    }


    private void CreateResetButton()
    {
        resetButton = new GameObject("ResetButton");
        resetButton.AddComponent<CanvasRenderer>();

        var canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("Zoom in requires a canvas!");
            return;
        }

        var button = resetButton.AddComponent<Button>();
        var image = resetButton.AddComponent<Image>();
        resetButton.transform.SetParent(canvas.transform);

        image.sprite = Resources.Load<Sprite>("exit_button"); 

        button.onClick.AddListener(() => StartCoroutine(ResetCameraCoroutine()));

        RectTransform rectTransform = resetButton.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(1, 1);
        rectTransform.anchorMax = new Vector2(1, 1); 
        rectTransform.pivot = new Vector2(1, 1); 
        rectTransform.anchoredPosition = new Vector2(-10, -10); 
        rectTransform.sizeDelta = new Vector2(100, 100); 

        resetButton.SetActive(false);
    }


    private void OnMouseDown()
    {
        if (!zoomEnabled)
        {
            StartCoroutine(ZoomInCoroutine());

        }
    }

    private IEnumerator ZoomInCoroutine()
    {
        resetButton.SetActive(true);
        zoomEnabled = true;

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
        resetButton.SetActive(false);
        zoomEnabled = false;

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
