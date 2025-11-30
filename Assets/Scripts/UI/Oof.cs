    using UnityEngine;
    using UnityEngine.UI; // Required for UI elements
    using UnityEngine.SceneManagement; // Required for SceneManager
    using TMPro; // Required for TextMeshPro
public class Oof : MonoBehaviour
{
    Player player;
    private void Start()
    {
        player = GameObject.Find("Player_Manager").GetComponent<Player>();
    }
    public void OnButtonClick()
    {
        Debug.Log("Button Clicked!");
        Life_Manager.TakeDamage(ref player.health, 10);
    }
}
