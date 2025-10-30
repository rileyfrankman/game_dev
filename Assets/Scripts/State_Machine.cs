using UnityEngine;

public class State_Machine : MonoBehaviour
{
    public string currentState;
    public Canvas World_Map;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = "World_Map";
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == "World_Map")
        {
            // World_Map.enabled = true;
        }
    }
}
