using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool spawn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawn == true)
        {
            Instantiate(Resources.Load<GameObject>("Prefabs/Enemy"), new Vector3(0, 0, 0), Quaternion.identity);
            spawn = false;  
        }
    }
}
