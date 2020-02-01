using UnityEngine;


[CreateAssetMenu(fileName = "KeyBinding", menuName = "ScriptableObjects/KeyBindingScriptableObject", order = 1)]
public class KeyBindingScriptableObject : ScriptableObject
{
    public KeyBinding playerOneKeyBinding;
    public KeyBinding playerTwoKeyBinding;
}

[System.Serializable]
public class KeyBinding
{
    public string moveUp;
    public string moveDown;
    public string moveLeft;
    public string moveRight;
    public string actionOne;
    public string actionTwo;
}
