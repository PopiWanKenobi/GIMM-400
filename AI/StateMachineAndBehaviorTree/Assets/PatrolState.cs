using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State {

    Vector3 destination;
    float rotationSpeed = 4;
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
            Quaternion toRotation = Quaternion.FromToRotation(stateController.ai.transform.position, destination);
            stateController.ai.transform.rotation = Quaternion.Lerp(stateController.ai.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            //stateController.ai.transform.LookAt(destination);
            stateController.ai.SetDestination(destination);

        }
    }
    public override void OnStateEnter()
    {
        stateController.ai.speed = stateController.speed;
        destination = stateController.GetNextNavPoint();
        stateController.ai.SetDestination(destination);
    }

}
