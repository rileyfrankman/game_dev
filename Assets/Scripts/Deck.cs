using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public class Deck
{
    [SerializeField] public List<Card> deck;
    [SerializeField] public List<Card> discardPile;
    [SerializeField] public List<Card> hand;
    
    public void Shuffle()
    {
        List<Card> cards = new List<Card>();
        cards.AddRange(deck);
        cards.AddRange(discardPile);
        deck.Clear();
        discardPile.Clear();
        Debug.Log("shuffling");

        for (int i = 0; i < cards.Count; i++)
        {
            int randomIndex = Random.Range(i, cards.Count);
            deck.Add(cards[randomIndex]);
            cards.RemoveAt(randomIndex);
        }
    }
}