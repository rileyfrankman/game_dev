using System.Collections.Generic; // Required for using List
using UnityEngine;
using System.Collections;

public class Enemy : Entity
{
    public bool dead;    
    // public List<Card> deck = new List<Card>(); // A list of ScriptableObject Deck
    string enemyName = "Goblin"; // Default enemy name
    
    public Canvas enemyUICanvas;
    public TMPro.TextMeshProUGUI enemyIntentText;
    public TMPro.TextMeshProUGUI enemyHealthText;
    public TMPro.TextMeshProUGUI enemyNameText;

    
    void LoadDeck()
    {
        Debug.Log("Loading enemy deck from Cards/EnemyDecks/" + enemyName);
        Card[] startingCards = Resources.LoadAll<Card>("Cards/EnemyDecks/" + enemyName);
        foreach (Card card in startingCards)
        {
            for (int i = 0; i < card.number; i++)
            {
                deck.deck.Add(card);
            }
        }
        deck.Shuffle();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        health = 10;
        dead = false;
        LoadDeck();
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
        
        enemyNameText.text = enemyName;
        if (block > 0)
        {
            enemyHealthText.text = "Health: " + health + " (Block: " + block + ")";
        }
        else
        {
            enemyHealthText.text = "Health: " + health;    
        }

        if (deck.hand.Count > 0)
        {
            if(deck.hand[0].attackFlag)
                enemyIntentText.text = "Intent: " + deck.hand[0].name + " (Damage: " + deck.hand[0].damage + ")";
            else if(deck.hand[0].blockFlag)
                enemyIntentText.text = "Intent: " + deck.hand[0].name + " (Block: " + deck.hand[0].block + ")";
            else if(deck.hand[0].healFlag)
                enemyIntentText.text = "Intent: " + deck.hand[0].name + " (Heal: " + deck.hand[0].heal + ")";
        }

        enemyUICanvas.enabled = !dead;
    }
}

