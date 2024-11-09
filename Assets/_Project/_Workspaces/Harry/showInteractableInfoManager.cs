using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays a game object's name to some text when clicked
/// Intended to be attached to a manager object
/// </summary>
public class showInteractableInfoManager : MonoBehaviour
{
    public Text dialogueText;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D hit = Physics2D.OverlapPoint(mousePosition);

            if (hit)
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
