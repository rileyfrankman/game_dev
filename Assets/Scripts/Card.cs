using UnityEngine;
[CreateAssetMenu(fileName = "Card", menuName = "Scriptable Objects/Card")]
public class Card : ScriptableObject
{
    public int damage = 1;
    // public string name = "Basic Attack";
    public string effect = "None";
    public int block = 0;
    public int staminaCost = 1;
    public int buff = 0;
    public int number = 1;
}
