using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class kbStats : MonoBehaviour
{
    private float health {get; set;} //= 70f;
    private float damage {get; set;} //= 30f;
    private float sight {get; set;} //= 8f;
    private float speed {get; set;} //= 2f;
    private float projectileSpeed {get; set;} //= 3f;
    private float cooldown {get; set;} //= 3.9f;

    protected string CheckValidity()
    {
        bool fail = false;
        output = "Here are the stats, they follow the rules! Health: " + health + " Damage: " +  damage + " Sight: " + sight + " Speed " + speed + " Cool down: " + cooldown + " Projectile Speed: " + projetileSpeed;

        if (health + damage > 100) 
        {
            fail = true;
        }
        if (sight + speed > 10)
        {
            fail = true;
        } 
        if (cooldown != projectileSpeed * 1.3)
        {
            fail = true;
        } 

        if(fail == true) 
        {
            output = "Here are the stats, they do not follow the rules! Health: " + health + " Damage: " +  damage + " Sight: " + sight + " Speed " + speed + " Cool down: " + cooldown + " Projectile Speed: " + projetileSpeed;
            health = 1;
            damage = 1;
            speed = 3;
            cooldown = 10;
            projectileSpeed = 1;
        }

        return output;
    }
}
