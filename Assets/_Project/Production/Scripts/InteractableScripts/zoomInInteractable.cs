using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class zoomInInteractable : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _originalCameraPosition;
    private float _originalZoom;
    private bool _zoomEnabled = false;

    public bool bypasssZoomConstraints = false;
    public bool disableResetButton = false;

    [SerializeField] private float zoomDuration = 0.5f;

    private GameObject _resetButton;

    public UnityEvent onZoomOutEvent; // Event triggered on zoom out

    void Start()
    {
        _camera = Camera.main;

        if (_camera != null && _camera.orthographic)
        {
            _originalCameraPosition = _camera.transform.position;
            _originalZoom = _camera.orthographicSize;
        }

        CreateResetButton();

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
        if (!_zoomEnabled && IsCameraAtOriginalPosition() || bypasssZoomConstraints)
        {
            StartCoroutine(ZoomInCoroutine());
        }
    }

    private IEnumerator ZoomInCoroutine()
    {
        if (!disableResetButton)
        {
            _resetButton.SetActive(true);

        }
        _zoomEnabled = true;

        Debug.Log("zoomin in");

        float elapsedTime = 0f;

        // Calculate the target position and zoom
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, _originalCameraPosition.z);
        float targetZoom = CalculateTargetZoom();

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

    private float CalculateTargetZoom()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogError("No Renderer found on the object to calculate zoom!");
            return _originalZoom;
        }

        Bounds bounds = renderer.bounds;

        float objectWidth = bounds.size.x;
        float objectHeight = bounds.size.y;

        float screenAspect = (float)Screen.width / (float)Screen.height;

        float zoomForWidth = objectWidth / (2f * screenAspect);
        float zoomForHeight = objectHeight / 2f;

        return Mathf.Max(zoomForWidth, zoomForHeight);
    }

    private IEnumerator ResetCameraCoroutine()
    {
        _resetButton.SetActive(false);
        _zoomEnabled = false;

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

    private bool IsCameraAtOriginalPosition()
    {
        // Check if the camera is at its original position and zoom level
        return _camera.transform.position == _originalCameraPosition && Mathf.Approximately(_camera.orthographicSize, _originalZoom);
    }

    private void OnDestroy()
    {
        if (_resetButton != null)
        {
            Destroy(_resetButton);
        }
    }
}
