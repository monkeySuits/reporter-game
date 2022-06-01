using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Item", menuName = "Create News")]
public class News : ScriptableObject

{
    [Header("Header")]
    public Color headerColor;
    public Sprite newspaperLogo;
    public string newspaperName;
    [Header("Body")]
    public Color bodyColor;
    public Sprite photograph;
    public string title;
    public string text;
    [Header("Notepad")]
    public string note;
    [Header("Good or Bad")]
    public string choice;
}
