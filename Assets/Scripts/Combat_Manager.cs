using UnityEngine;
using System.Collections.Generic;
using System.Threading;

public class Combat_Manager : MonoBehaviour
{
    public Player player;
    
    public GameObject enemyPrefab;
    private Enemy enemy;
    public Canvas rewardCanvas;
    public Canvas battleCanvas;
    public Canvas worldMap;
    public GameObject enemyObject;
    public GameObject playerObject;
    private readonly float cardSpacing = 300f;
    Vector3 enemyPosition = new Vector3(960, 800, 0);
    bool beginningOfTurn = true;
    public GameObject handManager;
    
    // private bool cardPlayable = false;
    public GameObject cardPrefab;
    public enum CombatState
    {
        Start,
        PlayerTurn,
        EnemyTurn,
        Victory,
        Defeat,
        OutOfCombat
    }

    private CombatState currentState;

    private void Start()
    {
        currentState = CombatState.OutOfCombat;
        battleCanvas.enabled = false;
    }

    public void InitializeCombat()
    {
        // player = GameObject.Find("Player_Manager").GetComponent<Player>();

        enemyObject = GameObject.Instantiate(enemyPrefab, enemyPosition, Quaternion.identity) as GameObject;        
        enemy = enemyObject.GetComponent<Enemy>();
        worldMap.enabled = false;
        battleCanvas.enabled = true;
        currentState = CombatState.Start;
        player.deck.Shuffle();
        enemy.deck.Shuffle();
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
        if (currentState != CombatState.OutOfCombat)
        {
            CheckGameState();            
        }
    }

    private void HandlePlayerTurn()
    {
        if (beginningOfTurn)
        { 
            if (player.deck.hand.Count != 0)
            {
                player.deck.DiscardHand();
                CleanUpHand();
            }
            DrawHands();
            Debug.Log("Player's Turn Begins");
            player.stamina = player.staminaMaxTemp - player.stun;
            player.staminaMaxTemp = player.staminaMax;
            
            if (player.stun > 0)
            {
                player.stun -= 1;
            }
            beginningOfTurn = false;
        }
        // cardPlayable = true;
    }

    private void HandleEnemyTurn()
    {
        // AI logic for enemy turn
        Debug.Log("Enemy is attacking...");
        Thread.Sleep(500); // Simulate time taken for enemy action
        if (enemy.stun > 0)
        {
            Debug.Log("Enemy is stunned and skips its turn.");
        }
        else
        {    
            enemy.PerformCard(enemyObject, ref playerObject,enemy.deck.hand[0]);
        }
        
        // After enemy turn completes:
        enemy.deck.discardPile.Add(enemy.deck.hand[0]);
        enemy.deck.hand.RemoveAt(0);
        currentState = CombatState.PlayerTurn;
        beginningOfTurn = true;
        UpdateConditions();
    }

    private void HandleVictory()
    {
        Debug.Log("Player Wins!");
        // Add victory logic
        rewardCanvas.enabled = true;
        EndCombat();
    }

    private void HandleDefeat()
    {
        Debug.Log("Player Loses!");
        // Add defeat logic
        EndCombat();
    }

    private void DrawHands()
    {
        EnemyDrawCard();
        for (int i = 0; i < player.handSize; i++)
        {
            DrawCard();
        }
    }
    public void EnemyDrawCard()
    {
        if (enemy.deck.deck.Count == 0)
        {
            enemy.deck.Shuffle();
        }
        Debug.Log("Number of cards in enemy deck before draw: " + enemy.deck.deck.Count);
        Card drawnCard = enemy.deck.deck[0];
        enemy.deck.deck.RemoveAt(0);
        enemy.deck.hand.Add(drawnCard);
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

        Vector3 cardPosition = new Vector3(1500 - cardSpacing * (numberOfCardsInHand - 1), 300, 0);
        GameObject cardObject = GameObject.Instantiate(cardPrefab, cardPosition, Quaternion.identity) as GameObject;
        cardObject.transform.SetParent(handManager.transform, false);
        cardObject.GetComponent<Card_Handler>().InitializeCard(card, cardObject);
    }
    public void CleanUpHand()
    {
        foreach (Transform child in handManager.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    public void EndPlayerTurn()
    {
        // cardPlayable = false;
        currentState = CombatState.EnemyTurn;
    }
    public void UpdateConditions()
    {
        enemy.block = 0;
        player.block = 0;   
        if (player.buff>0)
        {
            player.buff -= 1;
        }
        else if(player.buff<0)
        {
            player.buff +=1;    
        }

        if (enemy.buff>0)
        {
            enemy.buff -= 1;
        }
        else if(enemy.buff<0)
        {
            enemy.buff +=1;    
        }
        if (player.hide > 0)
        {
            player.hide -= 1;
        }
        if (enemy.hide > 0)
        {
            enemy.hide -= 1;
        }
    }
    public void CheckGameState()
    {
        if (enemy.health <= 0)
        {
            currentState = CombatState.Victory;
        }
        else if (player.health <= 0)
        {
            currentState = CombatState.Defeat;
        }
    }
    public void EndCombat()
    {
        currentState = CombatState.OutOfCombat;
        battleCanvas.enabled = false;
        beginningOfTurn = true;
    }
}
