using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActor {

    public bool CheckStats();
        
    public float Health { get; set; }

    public float Damage { get; set; }

    public float Sight { get; set; }

    public float Speed { get; set; }

    public float ProjectileSpeed { get; set; }

    public float Cooldown { get; set; }



}

