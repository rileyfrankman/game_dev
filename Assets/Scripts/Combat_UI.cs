using UnityEngine;

public class Combat_UI : MonoBehaviour
{
    private readonly float cardSpacing = 150f;
    public Player player;
    public GameObject cardPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void AddCardToHand(Card card)
    {
        // Add card to hand logic
        player.deck.hand.Add(card);
        int numberOfCardsInHand = player.deck.hand.Count;
        // GameObject cardObject = new GameObject();
        // Instantiate(cardObject);
        Vector3 cardPosition = new Vector3(-300 + cardSpacing * (numberOfCardsInHand - 1), -200, 0);
        
        GameObject cardObject = Instantiate(cardPrefab, cardPosition, Quaternion.identity);
        // gameO card_go = UnityEngine.Object.Instantiate(card, cardPosition, Quaternion.identity);
    }
}
