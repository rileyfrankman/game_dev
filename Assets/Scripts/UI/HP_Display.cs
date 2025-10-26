using UnityEngine;
using TMPro; // Required for TextMeshPro
using UnityEngine.UI; // Required for UI elements
public class HP_Display : MonoBehaviour
{
    public TextMeshProUGUI myTMPText; // Link this in the Inspector
    
    Player player;
    public Text text;
    void Start()
    {
        myTMPText.text = "Player HP: 100"; // Initial HP display
        player = GameObject.Find("Player_Manager").GetComponent<Player>();
    }

    void Update()
    {
        myTMPText.text = "Player HP: " + player.health.ToString();
        if (player.dead == true)
        {
            myTMPText.text = "DEAD :(";
        }
    }
}