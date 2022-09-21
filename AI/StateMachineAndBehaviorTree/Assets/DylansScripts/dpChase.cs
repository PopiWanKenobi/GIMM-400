using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dpChase : dpState
{
    public dpChase()
    {
        name = STATE.dpCHASE;
    }

    public override void Enter()
    {

        base.Enter();
    }

    public override void Update()
    {
        //Do whatever you want to do in Chase right here 


        //this if statement is the condition to switch from Chase to idle
        if (Random.Range(0, 100) < 100)
        {
            nextState = new dpIdle();
            stage = EVENT.EXIT;
        }

    }

    public override void Exit()
    {
        base.Exit();
    }
}
