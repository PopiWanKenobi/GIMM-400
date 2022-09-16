using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dpAI : dpStats
{
    //NavMeshAgent agent;
    public Transform player;
    kbState currentState;


    public dpAI instance;

    /*float _health;
    float _damage;
    float _sight;
    float _speed;
    float _projectileSpeed;
    float _cooldown;*/

    public dpAI()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        this.instance.health = 10f;
        this.instance.damage = 90f;
        this.instance.sight = 9f;
        this.instance.speed = 1f;
        this.instance.projectileSpeed = 6f;
        this.instance.cooldown = 7.8f;


        //stats = GetComponent<kbStats>();

        GetComponent<dpState>();

        //agent = GetComponent<NavMeshAgent>();
        //currentState = new kbidle(gameObject, agent, player);

       // Debug.Log(CheckValidity());

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
