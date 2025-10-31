using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Player : Entity
{
    public bool dead;
    public int gold;
    private string className = "Highwayman";
    public Deck deck = new Deck();

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
            Destroy(gameObject);
            dead = true;
        }
    }
}
