using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Prestige Item")]
[System.Serializable]
public class PrestigeData : ScriptableObject
{
    [TextArea]
    public List<string> Description;

    public int level;

    public int identifier;

    public int cost;
}