using UnityEngine;
using System.Collections.Generic;

public class Combat_Manager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public Canvas rewardCanvas;
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
        InitializeCombat();
    }

    private void InitializeCombat()
    {
        player = GameObject.Find("Player_Manager").GetComponent<Player>();
        // enemy = findObjectOfType<Enemy>();
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
        for (int i = 0; i < 5; i++)
        {
            player.deck.DrawCard();
            // DrawCard(enemyDeck, enemyHand);
        }
    }

    private void DrawCard(List<Card> deck, List<Card> hand)
    {
        if (deck.Count > 0)
        {
            hand.Add(deck[0]);
            deck.RemoveAt(0);
        }
    }

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
}