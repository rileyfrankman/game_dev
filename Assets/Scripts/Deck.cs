using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public class Deck
{
    [SerializeField] public List<Card> deck;
    [SerializeField] private List<Card> discardPile;
    [SerializeField] private List<Card> hand;

    public void Shuffle()
    {
        List<Card> cards = new List<Card>();
        cards.AddRange(deck);
        cards.AddRange(discardPile);
        deck.Clear();
        discardPile.Clear();

        for (int i = 0; i < cards.Count; i++)
        {
            Card temp = cards[i];
            int randomIndex = Random.Range(i, cards.Count);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }

    public void DrawCard()
    {
        if (deck.Count == 0)
        {
            Shuffle();
        }
        Card drawnCard = deck[0];
        deck.RemoveAt(0);
        hand.Add(drawnCard);
    }

}
