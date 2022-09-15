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

    float _health;
    float _damage;
    float _sight;
    float _speed;
    float _projectileSpeed;
    float _cooldown;

    public kbAI()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        stats = instance;

        stats = GetComponent<kbStats>();
        _health = instance.health;
        _damage = instance.damage;
        _sight = instance.sight;
        _speed = instance.speed;
        _projectileSpeed = instance.projectileSpeed;
        _cooldown = instance.cooldown;

        GetComponent<kbState>();
      
        //agent = GetComponent<NavMeshAgent>();
        //currentState = new kbidle(gameObject, agent, player);
        
        Debug.Log(CheckValidity());

        currentState = currentState.Process();
    }

    private void Update()
    {

    }

    //method all states can call MoveTowards()
}
