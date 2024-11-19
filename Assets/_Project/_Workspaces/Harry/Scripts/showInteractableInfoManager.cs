using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/// <summary>
/// Displays a game object's name to a TextMeshProUGUI text element when clicked.
/// Intended to be attached to a manager object.
/// </summary>
public class ShowInteractableInfoManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D hit = Physics2D.OverlapPoint(mousePosition);

            if (hit != null)
            {
                Debug.Log(hit);
                dialogueText.text = hit.transform.name;
            }
            else
            {
                dialogueText.text = "";
            }
        }
    }
}