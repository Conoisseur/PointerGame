
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PinSetter : MonoBehaviour
{
    private TextMeshProUGUI _textBox;
    [HideInInspector] public int pin = 0;
    
    private void Start()
    {
        _textBox = GetComponentInChildren<TextMeshProUGUI>();
    }
        
    public void IncrementPin()
    {
        pin = (pin + 1) % 10;
        _textBox.text = pin.ToString();
    }
    
    public void DecrementPin()
    {
        pin = (pin + 9) % 10;
        _textBox.text = pin.ToString();
    }
}
