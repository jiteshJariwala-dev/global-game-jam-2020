using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "ScriptableObjects/ItemsScriptableObject", order = 2)]
public class ItemsScriptableObject : ScriptableObject
{
    public List<ItemsForLevel> items;
}

[System.Serializable]
public class ItemsForLevel
{
    public List<GameObject> playerOneItems;
    public List<GameObject> playerTwoItems;

    public Vector3 playerOnePos;
    public Vector3 playerTwoPos;

    public int actionToWin;
}
