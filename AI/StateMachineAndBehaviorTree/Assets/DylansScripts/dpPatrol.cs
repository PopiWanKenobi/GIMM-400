using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dpPatrol : dpState
{
    public dpPatrol(GameObject _npc, NavMeshAgent _agent, Transform _player) : base(_npc, _agent, _player)
    {
        name = STATE.dpPATROL;
    }

    public override void Enter()
    {

        base.Enter();
    }

    public override void Update()
    {
        //Do whatever you want to do in Patrol right here 


        //this if statement is the condition to switch from idle to patrol
        if (Random.Range(0, 100) < 100)
        {
            nextState = new dpAttack(npc, agent, player);
            stage = EVENT.EXIT;
        }

    }

    public override void Exit()
    {
        base.Exit();
    }
}