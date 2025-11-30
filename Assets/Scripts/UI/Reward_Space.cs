    using UnityEngine;
    using UnityEngine.UI; // Required for UI elements
    using UnityEngine.SceneManagement; // Required for SceneManager
    using TMPro; // Required for TextMeshPro
public class Reward_Space : MonoBehaviour
{
    Player player;
    Canvas rewardCanvas;
    Canvas worldMap;
    public int rewardAmount = 10; // Example reward amount
    public string rewardType = "Gold"; // Example reward type
    public TextMeshProUGUI rewardText; // Link this in the Inspector
 
    private void Start()
    {
        player = GameObject.Find("Player_Manager").GetComponent<Player>();
        rewardCanvas = GameObject.Find("Reward_Screen").GetComponent<Canvas>();
        worldMap = GameObject.Find("World_Map").GetComponent<Canvas>();
        rewardCanvas.enabled = false;
    }
    public void OnButtonClick()
    {
        Debug.Log("Reward Button Chosen Clicked!");
        rewardCanvas.enabled = true;
        worldMap.enabled = false;

        if (rewardType == "Gold")
        {
            player.gold += rewardAmount;
            rewardText.text = "You stumble upon some salvage and find " + rewardAmount + " Gold!";
        }
        else if (rewardType == "Health")
        {
            player.health += rewardAmount;
            rewardText.text = "You rest and recover " + rewardAmount + " health.";
        }
    }
}
