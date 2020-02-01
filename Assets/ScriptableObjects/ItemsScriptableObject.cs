using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "ScriptableObjects/ItemsScriptableObject", order = 2)]
public class ItemsScriptableObject : ScriptableObject
{
    public List<GameObject> itemPrefabs;
}
