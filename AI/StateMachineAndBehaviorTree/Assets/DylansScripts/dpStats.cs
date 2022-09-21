using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class dpStats : dpState
{
    public abstract float health { get; set; }
    public abstract float damage { get; set; }
    public abstract float sight { get; set; }
    public abstract float speed { get; set; }
    public abstract float projectileSpeed { get; set; }
    public abstract float cooldown { get; set; }



    /*protected string CheckValidity()
    {
        bool fail = false;
        string output = "Here are the stats, they follow the rules! Health: " + health + " Damage: " + damage + " Sight: " + sight + " Speed " + speed + " Cool down: " + cooldown + " Projectile Speed: " + projectileSpeed;

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

        if (fail == true)
        {
            output = "Here are the stats, they do not follow the rules! Health: " + health + " Damage: " + damage + " Sight: " + sight + " Speed " + speed + " Cool down: " + cooldown + " Projectile Speed: " + projectileSpeed;
            health = 1;
            damage = 1;
            speed = 3;
            cooldown = 10;
            projectileSpeed = 1;
        }

        return output;
    }*/
}
