using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpScript : MonoBehaviour
{
    public int maxHealth = 100;
    public int armor;
    public int maxArmor;
    // Testing
    public bool shootSelf;
    public bool sharp;
    //
    // Regen time variables
    public float buffDegradeRate = .5f;
    private float timeStamp = 0;
    // End
    public bool isDead = false;
    private int overHeal;
    
    private int health_bar;

    // Start is called before the first frame update
    void Start()
    {
        maxArmor = 50;
        overHeal = maxHealth + 50;
        armor = 70;
        health_bar = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Debugging
        if(shootSelf)
        {
            actionDamage(12, sharp);
            shootSelf = false;
        }
        // Prevent going over limit
        if(armor > maxArmor)
            armor = maxArmor;

        if (health_bar >= overHeal)
            health_bar = overHeal;    

        // Degrade overheal buff overtime
        if (timeStamp <= Time.time && health_bar > maxHealth)
        {
            timeStamp = Time.time + buffDegradeRate;
            health_bar -= 1;
        }



        if (health_bar < 0)
            isDead = true;
    }

    public void actionArmor(int amount)
    {
        armor += amount;
    }

    public void actionDamage(int amount, bool piercing)
    {
        if(armor > 0 && !piercing)
        {
            armor -= amount;
            if (armor < 0)
            {
                health_bar += armor;
                armor = 0;
            }
        }
        else
            health_bar -= amount;
            
        Debug.Log("Player HP:" + health_bar);
        Debug.Log("Player Armor:" + armor);            
    }

    public void actionHeal(int amount)
    {
        health_bar += amount;
    }
}
