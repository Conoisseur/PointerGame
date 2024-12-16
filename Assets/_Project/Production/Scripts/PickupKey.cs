using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PickupKey : MonoBehaviour
{
    private GameObject _pickupButtonObject;
    private TMP_FontAsset _customFont;
    private DialogueBoxWriter _dialogueBoxWriter;

    void Start()
    {
        // If key already been picked up then destroy it in scene
        if (playerInventory.Instance.playerHasKey)
        {
            Destroy(gameObject);
            return;
        }

        _dialogueBoxWriter = FindObjectOfType<DialogueBoxWriter>();
        if (_dialogueBoxWriter == null)
        {
            Debug.LogError("DialogueBoxWriter component not found in the scene!");
        }

        CreateKeyPickupButton();
        _pickupButtonObject.SetActive(false);

        // Subscribe to the event in all zoomInInteractable instances in the scene
        var zoomInInteractableScripts = FindObjectsOfType<zoomInInteractable>();
        foreach (var script in zoomInInteractableScripts)
        {
            script.onZoomOutEvent.AddListener(HidePickupButton);
        }
    }

    private void CreateKeyPickupButton()
    {
        _pickupButtonObject = new GameObject("PickupButton");
        _pickupButtonObject.AddComponent<CanvasRenderer>();
        var pickupButton = _pickupButtonObject.AddComponent<Button>();
        var pickupImage = _pickupButtonObject.AddComponent<Image>();
        _pickupButtonObject.transform.SetParent(FindObjectOfType<Canvas>().transform);

        Color buttonColor = Color.black;
        buttonColor.a = 0.5f;
        pickupImage.color = buttonColor;

        var pickupButtonText = new GameObject("Text");
        pickupButtonText.transform.SetParent(_pickupButtonObject.transform);
        var textComponent = pickupButtonText.AddComponent<TextMeshProUGUI>();
        textComponent.text = "Take";
        textComponent.alignment = TextAlignmentOptions.Center;
        textComponent.color = Color.white;
        textComponent.font = _customFont;
        textComponent.fontSize = 80;

        RectTransform pickupRectTransform = _pickupButtonObject.GetComponent<RectTransform>();
        pickupRectTransform.sizeDelta = new Vector2(800, 300);
        pickupRectTransform.anchorMin = new Vector2(0.5f, 1f);
        pickupRectTransform.anchorMax = new Vector2(0.5f, 1f);
        pickupRectTransform.pivot = new Vector2(0.5f, 1f);
        pickupRectTransform.anchoredPosition = new Vector2(0, -20);

        pickupButton.onClick.AddListener(PickupKeyAction);
    }

    public void HidePickupButton()
    {
        if (_pickupButtonObject != null)
        {
            _pickupButtonObject.SetActive(false);
        }
    }

    public void ShowPickupButton()
    {
        if (_pickupButtonObject != null)
        {
            _pickupButtonObject.SetActive(true);
        }
    }

    public void OnMouseDown()
    {
        ShowPickupButton();
    }

    private void PickupKeyAction()
    {
        playerInventory.Instance.playerHasKey = true;
        Debug.Log("Key picked up!");

        HidePickupButton();

        // Display dialogue message
        if (_dialogueBoxWriter != null)
        {
            _dialogueBoxWriter.type("You picked up the key");
        }

        Destroy(gameObject);

        // Reload the current scene
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    private void OnDestroy()
    {
        if (_pickupButtonObject != null)
        {
            Destroy(_pickupButtonObject);
        }
    }
}
