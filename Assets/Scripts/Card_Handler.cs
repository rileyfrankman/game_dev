using UnityEngine;
using UnityEngine.UI; // For UI elements like Image
using UnityEngine.EventSystems;
public class Card_Handler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Card cardData;
    public SpriteRenderer cardSpriteRenderer;
    public TMPro.TextMeshProUGUI cardNameText;
    public TMPro.TextMeshProUGUI cardEffectText;
    public TMPro.TextMeshProUGUI cardCostText;
    public SpriteRenderer cardBackgroundRenderer;
    private Player player;
    private GameObject enemy;
    private GameObject playerObject;
    private Transform originalParent;
    public Canvas cardCanvas;
    private Vector3 originalPosition;
    private bool inPlayArea = false;
    
    public void Awake()
    {
        player = GameObject.Find("Player_Manager").GetComponent<Player>();
        playerObject = GameObject.Find("Player_Manager");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void InitializeCard(Card card, GameObject cardObject)
    {
        cardData = card;
        cardSpriteRenderer.sprite = card.sprite;
        cardNameText.text = card.name;
        cardEffectText.text = card.effect;
        cardCostText.text = card.staminaCost.ToString();
        // You can set other UI elements similarly

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Optional: Add logic for when dragging starts
        originalParent = this.transform.parent;
        this.transform.SetParent(this.transform.root); // Move to top-level to avoid being clipped
        cardCanvas.sortingOrder = 10; // Bring to front
        originalPosition = this.transform.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        // Move the card with the mouse
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(
            cardCanvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out globalMousePos))
        {
            this.transform.position = globalMousePos;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        // Optional: Add logic for when dragging ends
        this.transform.SetParent(originalParent); // Return to original parent
        cardCanvas.sortingOrder = 0; // Reset sorting order
        if (inPlayArea && player.stamina >= cardData.staminaCost)
        {
            
            enemy = GameObject.Find("Enemy(Clone)");
            Debug.Log("Card played: " + cardData.name);
            // Add logic for playing the card
            player.PerformCard(playerObject, ref enemy,this.cardData);
            player.deck.discardPile.Add(cardData);
            player.deck.hand.Remove(cardData);
            Destroy(this.gameObject); // Remove card from hand after playing
        }
        else
        {
            // Return to original position if not played
            this.transform.position = originalPosition;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("colliding");
        if (collision.gameObject.CompareTag("Play_Area"))
        {
            inPlayArea = true;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Play_Area"))
        {
            inPlayArea = false;
        }
    }
}
