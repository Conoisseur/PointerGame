using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PinlockManager : MonoBehaviour
{
    
    [SerializeField] private List<int> unlockedPins;
    private List<int> _currentPins;
    
    [SerializeField] private GameObject pinPrefab;
    
    private TextMeshProUGUI[] _pinTexts;
    

    void Start()
    {
        for (int i = 0; i < unlockedPins.Count; i++)
        {
            Instantiate(pinPrefab, this.transform);
        }
        
        _pinTexts = GetComponentsInChildren<TextMeshProUGUI>();

        for (int i = 0; i < _pinTexts.Length; i++)
        {
            _pinTexts[i].text = _currentPins[i].ToString();
        }
    }

    private void UpdatePins()
    {
        
    }
    
}
