using UnityEngine;

public class Player : Entity
{
    public bool dead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 20;
        dead = false;        
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Player has died.");
            Destroy(gameObject);
            dead = true;
        }

    }
    

}
