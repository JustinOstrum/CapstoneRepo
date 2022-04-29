using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ToolsDataObject", order = 2)]
public class ToolsData : ScriptableObject
{
    public List<GameObject> tools = new List<GameObject>();    
}
