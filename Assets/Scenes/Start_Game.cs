    using UnityEngine;
    using UnityEngine.UI; // Required for UI elements
    using UnityEngine.SceneManagement; // Required for SceneManager

    public class Start_Game : MonoBehaviour
    {
        public void OnButtonClick()
        {
            Debug.Log("Button Clicked!");
            // Add your desired actions here
            SceneManager.LoadScene("Overworld"); // Replace "GameScene" with your actual scene name
        }
    }
