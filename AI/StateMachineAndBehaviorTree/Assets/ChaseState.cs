using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State {

    Vector3 destination;


    public ChaseState(StateController stateController) : base(stateController) { }

    public override void CheckTransitions()
    {
        if (!stateController.CheckIfInRange())
        {
            stateController.SetState(new PatrolState(stateController));
        }

        if (Vector3.Distance(destination, stateController.ai.transform.position) < 3 )
        {
            stateController.ai.speed = 0;
            stateController.ai.velocity = Vector3.zero;
            //Debug.Log(Vector3.Distance(destination, stateController.ai.transform.position));

            stateController.SetState(new AttackState(stateController));

        }

    }
    public override void Act()
    {
        if(stateController.enemyToChase != null)
        {
            destination = stateController.enemyToChase.transform.position;
            stateController.ai.transform.LookAt(destination);
            stateController.ai.SetDestination(destination);
        }
    }
    public override void OnStateEnter()
    {

    }
}
