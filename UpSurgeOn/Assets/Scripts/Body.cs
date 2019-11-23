using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Body Parts", menuName = "Body Part")]
public class Body : ScriptableObject
{
    public string IdName;

    public new string name;
    public string description;

    public AudioClip clickSound;

    public Color enableColor;
    public Color disableColor;
}
