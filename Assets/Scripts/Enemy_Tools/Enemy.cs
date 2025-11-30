using System.Collections.Generic; // Required for using List
using UnityEngine;

public class Enemy : Entity
{
    public bool dead;    
    public List<Card> Deck = new List<Card>(); // A list of ScriptableObject Deck
    string enemyName = "Goblin"; // Default enemy name
    
    public Canvas enemyUICanvas;
    public TMPro.TextMeshProUGUI enemyIntentText;
    public TMPro.TextMeshProUGUI enemyHealthText;
    public TMPro.TextMeshProUGUI enemyNameText;

    
    void LoadDeck(string enemyName)
    {
        // Clear the current list of attacks
        // Deck.Clear();

        // // Load all Card ScriptableObjects from the Resources/Deck folder
        // Card[] Deck = Resources.LoadAll<Card>("Goblin_Deck");
     
        // For demonstration, we'll add all loaded attacks to the enemy's attack list
        // foreach (Card card in Deck)
        // {
        //     Deck.Add(card);
        //     Debug.Log("Loaded attack: " + Card.name + " for enemy: " + enemyName);
        // }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 10;
        dead = false;
        // LoadDeck(Enemy.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Enemy has died.");
            Destroy(gameObject);
            dead = true;
        }
        
        enemyUICanvas.enabled = !dead;
        enemyNameText.text = enemyName;
        enemyHealthText.text = "Health: " + health;
        enemyIntentText.text = "Attack 3";
    }
}

