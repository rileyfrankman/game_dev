using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public class Deck
{
    [SerializeField] public List<Card> deck;
    [SerializeField] private List<Card> discardPile;
    [SerializeField] private List<Card> hand;
    private readonly float cardSpacing = 150f;
    
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

    public void DrawCard()
    {
        if (deck.Count == 0)
        {
            Shuffle();
        }
        Card drawnCard = deck[0];
        deck.RemoveAt(0);
        AddCardToHand(drawnCard);
    }

    void AddCardToHand(Card card)
    {
        // Add card to hand logic
        hand.Add(card);
        int numberOfCardsInHand = hand.Count;
        Vector3 cardPosition = new Vector3(-300 + cardSpacing * (numberOfCardsInHand - 1), -200, 0);
        Card card_go = UnityEngine.Object.Instantiate(card, cardPosition, Quaternion.identity);
    }
}