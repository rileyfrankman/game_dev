using UnityEngine;

public class Card_Handler : MonoBehaviour
{
    public Card cardData;
    public SpriteRenderer cardSpriteRenderer;
    public TMPro.TextMeshProUGUI cardNameText;
    public TMPro.TextMeshProUGUI cardEffectText;
    public SpriteRenderer cardBackgroundRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void InitializeCard(Card card, GameObject cardObject)
    {
        cardData = card;
        cardSpriteRenderer.sprite = card.sprite;
        cardNameText.text = card.name;
        cardEffectText.text = card.effect;
        // You can set other UI elements similarly
    }
}
