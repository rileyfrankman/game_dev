using UnityEngine;
using TMPro; // Required for TextMeshPro
using UnityEngine.UI; // Required for UI elements
public class HUD_Display : MonoBehaviour
{
    public TextMeshProUGUI goldText; // Link this in the Inspector
    public TextMeshProUGUI healthText; // Link this in the Inspector
    
    Player player;
    void Start()
    {
        player = GameObject.Find("Player_Manager").GetComponent<Player>();
    }

    void Update()
    {
        healthText.text = "Player HP: " + player.health.ToString();
        if (player.dead == true)
        {
            healthText.text = "DEAD :(";
        }

        goldText.text = "Gold: " + player.gold.ToString();
    }
}