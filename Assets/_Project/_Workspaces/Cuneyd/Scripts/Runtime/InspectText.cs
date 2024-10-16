using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InspectText", menuName = "Narrative/InspectText")]
public class InspectText : ScriptableObject
{
    [TextArea]
    public string text;
}
