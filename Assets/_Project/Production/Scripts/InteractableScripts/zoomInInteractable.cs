using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;  // Import UnityEvents

[RequireComponent(typeof(BoxCollider2D))]
public class zoomInInteractable : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _originalCameraPosition;
    private float _originalZoom;
    private bool _zoomEnabled = false;

    [SerializeField] private float zoomFactor = 0.4f;
    [SerializeField] private float zoomDuration = 0.5f;

    private GameObject _resetButton;

    // Define the event to show/hide the pickup button
    public UnityEvent onZoomOutEvent;  // Event that will be triggered when zooming out

    [Serializable]
    public enum AudioTrigger
    {
        Cymbal,
        Marimba,
        Clock,
        Victory,
        ClueComplete
    }

    public void TriggerAudio(int audioTrigger)
    {
        switch (audioTrigger)
        {
            case 0:
                MUZIKSKRIPT.Instance.OnFindingHiddenMessage();
                break;
            case 1:
                MUZIKSKRIPT.Instance.OnFindingHiddenObject();
                break;
            case 2:
                MUZIKSKRIPT.Instance.OnAlphabetScriptThing();
                break;
            case 3:
                MUZIKSKRIPT.Instance.OnVictory();
                break;
            case 4:
                MUZIKSKRIPT.Instance.OnClueComplete();
                break;
        }
    }
    
    void Start()
    {
        _camera = Camera.main;

        if (_camera != null && _camera.orthographic)
        {
            _originalCameraPosition = _camera.transform.position;
            _originalZoom = _camera.orthographicSize;
        }

        CreateResetButton();

        // If the event is not assigned, we assign a default listener
        if (onZoomOutEvent == null)
            onZoomOutEvent = new UnityEvent();
    }

    private void CreateResetButton()
    {
        _resetButton = new GameObject("ResetButton");
        _resetButton.AddComponent<CanvasRenderer>();

        var canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("Zoom in requires a canvas!");
            return;
        }

        var button = _resetButton.AddComponent<Button>();
        var image = _resetButton.AddComponent<Image>();
        _resetButton.transform.SetParent(canvas.transform);

        image.sprite = Resources.Load<Sprite>("exit_button");

        button.onClick.AddListener(() => StartCoroutine(ResetCameraCoroutine()));

        RectTransform rectTransform = _resetButton.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(1, 1);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(1, 1);
        rectTransform.anchoredPosition = new Vector2(-10, -10);
        rectTransform.sizeDelta = new Vector2(500, 500);

        _resetButton.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!_zoomEnabled)
        {
            StartCoroutine(ZoomInCoroutine());
        }
    }

    private IEnumerator ZoomInCoroutine()
    {
        _resetButton.SetActive(true);
        _zoomEnabled = true;

        float elapsedTime = 0f;
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, _originalCameraPosition.z);
        float targetZoom = Mathf.Max(0.1f, _originalZoom * zoomFactor);

        while (elapsedTime < zoomDuration)
        {
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, targetPosition, elapsedTime / zoomDuration);
            _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, targetZoom, elapsedTime / zoomDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _camera.transform.position = targetPosition;
        _camera.orthographicSize = targetZoom;
    }

    private IEnumerator ResetCameraCoroutine()
    {
        _resetButton.SetActive(false);
        _zoomEnabled = false;

        // Trigger the event to hide the pickup button when zooming out
        if (onZoomOutEvent != null)
            onZoomOutEvent.Invoke();

        float elapsedTime = 0f;
        Vector3 targetPosition = _originalCameraPosition;
        float targetZoom = _originalZoom;

        while (elapsedTime < zoomDuration)
        {
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, targetPosition, elapsedTime / zoomDuration);
            _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, targetZoom, elapsedTime / zoomDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _camera.transform.position = targetPosition;
        _camera.orthographicSize = targetZoom;
    }

    private void OnDestroy()
    {
        if (_resetButton != null)
        {
            Destroy(_resetButton);
        }
    }
}
