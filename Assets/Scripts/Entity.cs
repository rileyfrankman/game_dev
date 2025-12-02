using UnityEngine;
using static Life_Manager;
public class Entity : MonoBehaviour
{
    public int health = 10;
    public int buff = 0;
    public int block = 0;
    public Deck deck = new Deck();
    public int hide = 0;
    public int stun = 0;
        
        
    public void PerformCard(GameObject attacker, ref GameObject target, Card action)
    {
        if (action == null)
        {
            Debug.LogWarning("No action provided for PerformCard.");
            return;
        }
        if (action.buffFlag)
        {
            buff += action.buff;
            Debug.Log(attacker.name + " buffs themselves for " + action.buff + ". New buff: " + buff);
            HandleEffects(action, attacker, target);
            return;
        }
        if (action.healFlag)
        {
            GainHealth(ref attacker.GetComponent<Entity>().health, action.heal);
            Debug.Log(attacker.name + " heals for " + action.heal + ". New health: " + attacker.GetComponent<Entity>().health);
            HandleEffects(action, attacker, target);
            return;
        }
        if (action.blockFlag)
        {
            attacker.GetComponent<Entity>().block += action.block;
            Debug.Log(attacker.name + " gains " + action.block + " block. New block: " + attacker.GetComponent<Entity>().block);
            HandleEffects(action, attacker, target);
            return;
        }
        if (action.attackFlag)
        {
            int damage = action.damage + attacker.GetComponent<Entity>().buff  - target.GetComponent<Entity>().hide;
            int block = target.GetComponent<Entity>().block;
            switch (action.effect)
            {
                case "critical":
                    if (block == 0)
                    damage *= 2;
                    break;
                case "fear":
                    target.GetComponent<Entity>().buff -= 2;
                    break;
                case "break":
                    if (block > 0)
                    {
                    damage += Mathf.FloorToInt(block / 2);
                    }
                    break;
                default:
                    break;
            }
            Debug.Log(attacker.name + " performs " + action.name + " on " + target.name + ", dealing " + damage + " damage with effect: " + action.effect);
            int temp_block = block;
            temp_block -= damage;

            if (temp_block < 0)
            {
                damage -= block;
                block = 0;
            }
            else
            {
                damage = 0;
                block = temp_block;
            }
            target.GetComponent<Entity>().block = block;
            
            HandleEffects(action, attacker, target, damage);
            TakeDamage(ref target.GetComponent<Entity>().health, damage);
        }
        if (!action.attackFlag && !action.blockFlag && !action.healFlag && !action.buffFlag)
        {
            Debug.LogWarning("Card " + action.name + " has no valid action flags set.");
        }
        if (attacker.GetComponent<Player>() != null)
        {
            attacker.GetComponent<Player>().stamina -= action.staminaCost;
            Debug.Log(attacker.name + " uses " + action.staminaCost + " stamina. Remaining stamina: " + attacker.GetComponent<Player>().stamina);
        }
    }
    private void HandleEffects(Card action, GameObject attacker, GameObject target, int damageDealt = 0)
    {
        
        bool stealflag = action.effect == "steal";
        if (stealflag && damageDealt > 0 && attacker.GetComponent<Player>() != null)
        {
            int stealAmount = Mathf.FloorToInt(damageDealt / 2);
            attacker.GetComponent<Player>().gold += stealAmount;
            Debug.Log(attacker.name + " steals " + stealAmount + " health from " + target.name + ". New health: " + attacker.GetComponent<Entity>().health);
        }        
        if (action.effect == "slow")
        {
            attacker.GetComponent<Entity>().stun += 1;
        }
        if (action.effect == "stun")
        {
            target.GetComponent<Entity>().stun += 1;
        }
        if (action.effect == "hide")
        {
            attacker.GetComponent<Entity>().hide += 1;
        }
    }    
}
