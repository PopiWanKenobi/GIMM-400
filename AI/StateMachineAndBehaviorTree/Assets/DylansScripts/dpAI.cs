using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dpAI : dpStats
{
    //NavMeshAgent agent;
    //public Transform player;
    dpState currentState;


    public dpAI instance;

    float _health;
    float _damage;
    float _sight;
    float _speed;
    float _projectileSpeed;
    float _cooldown;

    public dpAI()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {

        _health = 10f;
        _damage = 90f;
        _sight = 9f;
        _speed = 1f;
        _projectileSpeed = 6f;
        _cooldown = 7.8f;


        //stats = GetComponent<kbStats>();

        this.GetComponent<dpState>();


        currentState = new dpIdle();

        //currentState = currentState.Process();
        Debug.Log(currentState);

        //this.Process();

    }

    public override float health
    {
        get
        {
            return _health;
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
            return _damage;
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
            return _sight;
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
            return _speed;
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
            return _projectileSpeed;
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
            return _cooldown;
        }
        set
        {
            cooldown = value;
        }
    }

    public override void Update()
    {
        currentState = currentState.Process();
    }

    //method all states can call MoveTowards()
}
