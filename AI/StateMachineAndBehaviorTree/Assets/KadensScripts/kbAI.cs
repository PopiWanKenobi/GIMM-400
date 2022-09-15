using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class kbAI : kbStats
{
    //NavMeshAgent agent;
    public Transform player;
    kbState currentState;


    public kbAI instance;

    /*float _health;
    float _damage;
    float _sight;
    float _speed;
    float _projectileSpeed;
    float _cooldown;*/

    public kbAI()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        this.instance.health = 70f;
        this.instance.damage = 30f;
        this.instance.sight = 8f;
        this.instance.speed = 2f;
        this.instance.projectileSpeed = 3f;
        this.instance.cooldown = 3.9f;


        //stats = GetComponent<kbStats>();

        GetComponent<kbState>();
      
        //agent = GetComponent<NavMeshAgent>();
        //currentState = new kbidle(gameObject, agent, player);
        
        Debug.Log(CheckValidity());

        currentState = currentState.Process();
    }

    public override float health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
    public override float damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }
    public override float sight
    {
        get
        {
            return sight;
        }
        set
        {
            sight = value;
        }
    }
    public override float speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
    public override float projectileSpeed
    {
        get
        {
            return projectileSpeed;
        }
        set
        {
            projectileSpeed = value;
        }
    }
    public override float cooldown
    {
        get
        {
            return cooldown;
        }
        set
        {
            cooldown = value;
        }
    }

    private void Update()
    {

    }

    //method all states can call MoveTowards()
}
