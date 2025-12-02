using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class Player : Entity
{
    public bool dead;
    public int gold;
    public int staminaMax = 3;
    public int staminaMaxTemp = 3;
    public int stamina = 3;
    public int handSize = 5;
    private string className = "Highwayman";
    public Canvas playerUICanvas;
    public Canvas GameOverCanvas;
    public TMPro.TextMeshProUGUI GameOverText;
    public TMPro.TextMeshProUGUI playerGoldText;
    public TMPro.TextMeshProUGUI playerHealthText;
    public TMPro.TextMeshProUGUI playerStaminaText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 20;
        dead = false;
        gold = 10;

        Debug.Log("Deck is null, initializing new Deck from Cards/StartingDeck/" + className);
        Card[] startingCards = Resources.LoadAll<Card>("Cards/StartingDeck/" + className);
        foreach (Card card in startingCards)
        {
            for (int i = 0; i < card.number; i++)
            {
                deck.deck.Add(card);
            }
        }
        
        playerUICanvas.enabled = true;
        GameOverCanvas.enabled = false;

    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Player has died.");
            // Destroy(gameObject);
            GameOverCanvas.enabled = true;
            GameOverText.text = "You have died with, there were still adventures left to be had...";
            dead = true;
        }
        playerUICanvas.enabled = !dead;
        playerGoldText.text = "Gold: " + gold;
        if (block > 0)
        {
            playerHealthText.text = "Health: " + health + " (Block: " + block + ")";
        }
        else
        {
            playerHealthText.text = "Health: " + health;    
        }
        
        playerStaminaText.text = "Stamina: " + stamina;
    }
}
