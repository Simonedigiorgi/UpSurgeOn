using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Body Parts", menuName = "Body Part")]
public class BodyParts : ScriptableObject
{
    public string bodyPartName;

    public Color enableColor;
    public Color disableColor;
}
