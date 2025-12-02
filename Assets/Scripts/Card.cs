using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[CreateAssetMenu(fileName = "Card", menuName = "Scriptable Objects/Card")]
[System.Serializable]
public class Card : ScriptableObject
{
    public int id;
    public int damage = 1;
    public string effect = "None";
    public int block = 0;
    public int heal = 0;
    public int staminaCost = 1;
    public int buff = 0;
    public int number = 1;
    public Sprite sprite;
    public int orderInDeck = 0;
    public Transform cardTransform;
    public bool attackFlag = true;
    public bool blockFlag = false; 
    public bool healFlag = false; 
    public bool buffFlag = false; 
    public string cardText = "Default Card Text";
}
