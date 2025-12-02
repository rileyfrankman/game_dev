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

        while (cards.Count > 0)
        {
            int randomIndex = Random.Range(0, cards.Count);
            deck.Add(cards[randomIndex]);
            cards.RemoveAt(randomIndex);
        }
    }
    public void DiscardHand()
    {
        discardPile.AddRange(hand);
        hand.Clear();
    }
}