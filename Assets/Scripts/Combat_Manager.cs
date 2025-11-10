using UnityEngine;
using System.Collections.Generic;

public class Combat_Manager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public Canvas rewardCanvas;
    public Canvas BattleCanvas;
    public Canvas worldMap;
    private readonly float cardSpacing = 150f;
    
    public GameObject cardPrefab;
    public enum CombatState
    {
        Start,
        PlayerTurn,
        EnemyTurn,
        Victory,
        Defeat
    }

    private CombatState currentState;

    private void Start()
    {
    }

    public void InitializeCombat()
    {
        // player = GameObject.Find("Player_Manager").GetComponent<Player>();
        // enemy = findObjectOfType<Enemy>();
        worldMap.enabled = false;
        currentState = CombatState.Start;
        player.deck.Shuffle();
        // ShuffleDeck(enemyDeck);
        DrawInitialHands();
        currentState = CombatState.PlayerTurn;
    }

    private void Update()
    {
        switch (currentState)
        {
            case CombatState.PlayerTurn:
                HandlePlayerTurn();
                break;
            case CombatState.EnemyTurn:
                HandleEnemyTurn();
                break;
            case CombatState.Victory:
                HandleVictory();
                break;
            case CombatState.Defeat:
                HandleDefeat();
                break;
        }
    }

    private void HandlePlayerTurn()
    {
        // Handle player card selection and playing
        // This would be implemented based on your input system
    }

    private void HandleEnemyTurn()
    {
        // AI logic for enemy turn
        // After enemy turn completes:
        currentState = CombatState.PlayerTurn;
    }

    private void HandleVictory()
    {
        Debug.Log("Player Wins!");
        // Add victory logic
    }

    private void HandleDefeat()
    {
        Debug.Log("Player Loses!");
        // Add defeat logic
    }

    private void DrawInitialHands()
    {
        for (int i = 0; i < 1; i++)
        {
            DrawCard();
            // DrawCard(enemyDeck, enemyHand);
        }
    }

    // private void DrawCard(List<Card> deck, List<Card> hand)
    // {
    //     if (deck.Count > 0)
    //     {
    //         addCardToHand(deck[0]);
    //         player.deck.RemoveAt(0);
    //     }
    // }

    // Check win/lose conditions
    private void CheckGameState()
    {
        if (enemy.health <= 0)
        {
            currentState = CombatState.Victory;
            rewardCanvas.enabled = true;
        }
        else if (player.health <= 0)
        {
            currentState = CombatState.Defeat;
        }
    }

        public void DrawCard()
    {
        if (player.deck.deck.Count == 0)
        {
            player.deck.Shuffle();
        }
        Card drawnCard = player.deck.deck[0];
        player.deck.deck.RemoveAt(0);
        AddCardToHand(drawnCard);
    }
        private void AddCardToHand(Card card)
    {
        // Add card to hand logic
        player.deck.hand.Add(card);
        int numberOfCardsInHand = player.deck.hand.Count;
        // GameObject cardObject = new GameObject();
        // Instantiate(cardObject);
        Vector3 cardPosition = new Vector3(-300 + cardSpacing * (numberOfCardsInHand - 1), -200, 0);
        GameObject cardObject = GameObject.Instantiate(cardPrefab, cardPosition, Quaternion.identity) as GameObject;
        cardObject.GetComponent<Card_Handler>().InitializeCard(card, cardObject);
        // gameO card_go = UnityEngine.Object.Instantiate(card, cardPosition, Quaternion.identity);
    }
}
