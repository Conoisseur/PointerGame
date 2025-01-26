using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class Lock : MonoBehaviour
{
    public DialogueSO noKeyDialogueSO;
    public DialogueSO hasKeyDialogueSO;
    public string winMessage = "You Win!";
    private float delayBeforeQuit = 10f;

    private DialogueBoxWriter _dialogueBoxWriter;
    private GameObject _insertKeyButtonObject;
    private TMP_FontAsset _customFont;
    private void Start()
    {
        _dialogueBoxWriter = FindObjectOfType<DialogueBoxWriter>();

        if (_dialogueBoxWriter == null)
        {
            Debug.LogError("DialogueBoxWriter not found in the scene!");
        }

        CreateInsertKeyButton();
        _insertKeyButtonObject.SetActive(false);
    }

    private void CreateInsertKeyButton()
    {
        _insertKeyButtonObject = new GameObject("InsertKeyButton");
        _insertKeyButtonObject.AddComponent<CanvasRenderer>();
        var insertKeyButton = _insertKeyButtonObject.AddComponent<Button>();
        var buttonImage = _insertKeyButtonObject.AddComponent<Image>();
        _insertKeyButtonObject.transform.SetParent(FindObjectOfType<Canvas>().transform);

        Color buttonColor = Color.black;
        buttonColor.a = 0.5f;
        buttonImage.color = buttonColor;

        var buttonText = new GameObject("Text");
        buttonText.transform.SetParent(_insertKeyButtonObject.transform);
        var textComponent = buttonText.AddComponent<TextMeshProUGUI>();
        textComponent.text = "Use Key";  
        textComponent.alignment = TextAlignmentOptions.Center;
        textComponent.color = Color.white;
        textComponent.font = _customFont;
        textComponent.fontSize = 80;

        RectTransform rectTransform = _insertKeyButtonObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(800, 300);
        rectTransform.anchorMin = new Vector2(0.5f, 1f);
        rectTransform.anchorMax = new Vector2(0.5f, 1f);
        rectTransform.pivot = new Vector2(0.5f, 1f);
        rectTransform.anchoredPosition = new Vector2(0, -20);

        insertKeyButton.onClick.AddListener(InsertKeyAction);
    }

    private void OnMouseDown()
    {
        if (PlayerInventory.Instance != null && PlayerInventory.Instance.playerHasKey)
        {
            ShowInsertKeyButton();
        }
        else
        {
            ShowText(noKeyDialogueSO);
        }
    }

    private void ShowText(DialogueSO dialogueSo)
    {
        if (_dialogueBoxWriter == null)
        {
            _dialogueBoxWriter = FindObjectOfType<DialogueBoxWriter>();
        }

        if (dialogueSo != null)
        {
            string[] dialogues = dialogueSo.dialogues;
            int index = dialogueSo.dialogueIndex;

            if (index >= 0 && index < dialogues.Length)
            {
                _dialogueBoxWriter.type(dialogues[index]);
            }

            if (index < dialogues.Length - 1)
            {
                dialogueSo.dialogueIndex++;
            }
            else
            {
                dialogueSo.dialogueIndex = 0;
            }
        }
        else
        {
            Debug.LogError("DialogueSO is missing!");
        }
    }

    private void ShowInsertKeyButton()
    {
        if (_insertKeyButtonObject != null)
        {
            _insertKeyButtonObject.SetActive(true);
        }
    }

    private void HideInsertKeyButton()
    {
        if (_insertKeyButtonObject != null)
        {
            _insertKeyButtonObject.SetActive(false);
        }
    }

    private void InsertKeyAction()
    {
        if (_dialogueBoxWriter != null)
        {
            _dialogueBoxWriter.type(winMessage);
        }
        else
        {
            Debug.Log(winMessage);
        }

        _insertKeyButtonObject.SetActive(false);

        SpriteRenderer lockRenderer = GetComponent<SpriteRenderer>();
        if (lockRenderer != null)
        {
            lockRenderer.enabled = false;
        }

        StartCoroutine(EndGame());
    }


    private IEnumerator EndGame()
    {

        SceneLoader.Instance.LoadEndScene();

        yield return new WaitForSeconds(delayBeforeQuit);

        
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    private void OnDestroy()
    {
        if (_insertKeyButtonObject != null)
        {
            Destroy(_insertKeyButtonObject);
        }
    }



}
