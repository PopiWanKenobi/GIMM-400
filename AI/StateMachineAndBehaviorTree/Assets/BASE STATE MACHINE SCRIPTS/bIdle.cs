using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bIdle : bState
{
    public bIdle(GameObject _npc, NavMeshAgent _agent, Transform _player)
        : base(_npc, _agent, _player)
    {
        name = STATE.IDLE;
    }
    public override void Enter()
    {

        base.Enter();
    }
    public override void Update()
    {
        // do whatever you want to do in reload here


        //this if statement is the condition to switch from idle to patrol
        if (Random.Range(0, 100) < 100) //100 percent of the time swap to next state. This is the condition to exit
        {
            nextState = new bPatrol(npc, agent, player);
            stage = EVENT.EXIT;
        }

    }
    public override void Exit()
    {
        //anim.ResetTrigger("isIdle"); //takes out any sitting animations that didnt run
        base.Exit();
    }
}
