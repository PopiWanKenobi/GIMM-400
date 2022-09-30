using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    Vector3 destination;

    public AttackState(StateController stateController) : base(stateController) { }

    // Start is called before the first frame update
    public override void CheckTransitions()
    {
        if (!stateController.CheckIfInRange())
        {
            //stateController.ai.isStopped = false;
            stateController.SetState(new PatrolState(stateController));
        }

        if (Vector3.Distance(stateController.enemyToChase.transform.position, stateController.ai.transform.position) > 3.2f)
        {
            stateController.ai.speed = stateController.speed;
            stateController.SetState(new ChaseState(stateController));

        }
    }
    public override void Act()
    {
        

        //stateController.ai.transform.LookAt(destination);
        //Debug.Log("Start Attacking Brother");
    }


}
