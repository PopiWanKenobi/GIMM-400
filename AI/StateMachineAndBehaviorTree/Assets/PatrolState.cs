using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State {

    Vector3 destination;
    float rotation;
    float speed;

    public PatrolState(StateController stateController) : base(stateController) { }

    public override void CheckTransitions()
    {
        if (stateController.CheckIfInRange())
        {
            stateController.SetState(new ChaseState(stateController));
        }
    }
    public override void Act()
    {
        if(destination == null || stateController.ai.remainingDistance < 1f)
        {
            destination = stateController.GetNextNavPoint();
            stateController.ai.transform.LookAt(destination);
            stateController.ai.SetDestination(destination);

        }
    }
    public override void OnStateEnter()
    {
        destination = stateController.GetNextNavPoint();
        stateController.ai.SetDestination(destination);
    }

}
