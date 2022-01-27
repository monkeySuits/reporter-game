using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Item", menuName = "Create Item")]
public class Item : ScriptableObject
{
    [Header("Information")]
    public Sprite icon;
    public string displayName;
    public string description;
    [Header("Feedbacks")]
    public string collectHint;

    public int id {get; private set;}

    private void OnEnable(){
        id = this.GetInstanceID();
    }
}
