using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ShowEndDialogue : DialogueBoxWriter
{
    [TextArea(3, 10)]
    public string endText;
    private void Start()
    {
        type(endText);
    }
}
