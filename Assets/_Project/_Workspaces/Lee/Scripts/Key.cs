using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : ShowDialogue
{
    public GameObject door;
    private Door _doorScript;

    public void Start()
    {
        _doorScript = door.GetComponent<Door>();
        if (_doorScript == null)
        {
            Debug.Log("No door script attached to door!");
        }
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        _doorScript.SetHasKey();
        if (gameObject == null)
        {
            Debug.Log("Can't get the game object door script is attached to");
        }
        
        Destroy(gameObject);
    }
}
