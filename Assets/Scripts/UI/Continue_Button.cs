    using UnityEngine;
    using UnityEngine.UI; // Required for UI elements
    using UnityEngine.SceneManagement; // Required for SceneManager
    using TMPro; // Required for TextMeshPro
public class Continue_Button : MonoBehaviour
{
    Player player;
    Canvas worldMap;
    Canvas rewardCanvas;
    public TextMeshProUGUI continueButton;
    private void Start()
    {
        worldMap = GameObject.Find("World_Map").GetComponent<Canvas>();
        rewardCanvas = GameObject.Find("Reward_Screen").GetComponent<Canvas>();
        continueButton.text = "Continue";
    }
    public void OnButtonClick()
    {
        Debug.Log("Continue Button Chosen Clicked!");
        worldMap.enabled = true;
        if (rewardCanvas.enabled == true)
        {
            rewardCanvas.enabled = false;
        }
    }
    public void GameOverClick()
    {
        Debug.Log("Game Over Continue Button Clicked!");
        SceneManager.LoadScene("Main");
    }
}
