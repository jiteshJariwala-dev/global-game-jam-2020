using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "ScriptableObjects/ItemsScriptableObject", order = 2)]
public class ItemsScriptableObject : ScriptableObject
{
    public List<ItemsForLevel> items = new List<ItemsForLevel>();
}

[System.Serializable]
public class ItemsForLevel
{
    public List<GameObject> playerOneItems = new List<GameObject>();
    public List<GameObject> playerTwoItems = new List<GameObject>();

    public Vector3 playerOnePos;
    public Vector3 playerTwoPos;

    public int actionToWin;
}
