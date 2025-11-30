using UnityEngine;
using UnityEngine.UI; // For UI elements like Image
using UnityEngine.EventSystems;
public class Card_Handler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Card cardData;
    public SpriteRenderer cardSpriteRenderer;
    public TMPro.TextMeshProUGUI cardNameText;
    public TMPro.TextMeshProUGUI cardEffectText;
    public SpriteRenderer cardBackgroundRenderer;
    private Transform originalParent;
    public Canvas cardCanvas;
    private Vector3 originalPosition;
    private bool inPlayArea = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void InitializeCard(Card card, GameObject cardObject)
    {
        cardData = card;
        cardSpriteRenderer.sprite = card.sprite;
        cardNameText.text = card.name;
        cardEffectText.text = card.effect;
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
        if (inPlayArea)
        {
            Debug.Log("Card played: " + cardData.name);
            // Add logic for playing the card
            // Destroy(this.gameObject); // Remove card from hand after playing
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
