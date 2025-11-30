using UnityEngine;
public static class Life_Manager
{    
        
    public static void PerformCard(GameObject attacker, ref GameObject target, Card attack)
    {
        int damage = attack.damage + attacker.GetComponent<Entity>().buff;
        Debug.Log(attacker.name + " performs " + attack.name + " on " + target.name + ", dealing " + damage + " damage with effect: " + attack.effect);
        // Here you can add logic to reduce the target's health, apply effects, etc.
        TakeDamage(ref target.GetComponent<Entity>().health, damage);

    }

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
