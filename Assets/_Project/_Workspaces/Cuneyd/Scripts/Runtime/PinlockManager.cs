using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PinlockManager : MonoBehaviour
{
    
    [SerializeField] private List<int> unlockedPins;
    private PinSetter[] _currentPins;
    
    [SerializeField] private GameObject pinPrefab;

    private bool _allMatch = false;
    
    [SerializeField] private UnityEvent onUnlocked;
    

    void Start()
    {
        
        for (int i = 0; i < unlockedPins.Count; i++)
        {
            Instantiate(pinPrefab, this.transform);
        }
        
        _currentPins = GetComponentsInChildren<PinSetter>();
        CheckUnlocked();
    }

    public void CheckUnlocked()
    {
        _allMatch = true;
        for (int i = 0; i < _currentPins.Length; i++)
        {
            if (_currentPins[i].pin != unlockedPins[i])
            {
                _allMatch = false;
                break;
            }
        }

        if (_allMatch)
        {
            Debug.Log("All pins unlocked");
            onUnlocked.Invoke();
        }
    }
    
}
