using UnityEngine;
public static class Life_Manager
{
    public static void TakeDamage(ref int health, int damage)
    {
        health -= damage;
        Debug.Log(" took " + damage + " damage. Remaining health: " + health);
    }


    public static void GainHealth(ref int health, int amount)
    {
        health += amount;
        Debug.Log( " gained " + amount + " health. Current health: " + health);
    }
}
