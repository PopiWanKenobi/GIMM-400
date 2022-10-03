using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    float cooldown;
    public AttackState(StateController stateController) : base(stateController) { }

    // Start is called before the first frame update
    public override void CheckTransitions()
    {

        if (!stateController.CheckIfInRange())
        {
            //stateController.ai.isStopped = false;
            stateController.SetState(new PatrolState(stateController));
        }

        if (stateController.enemyToChase != null)
        {
            if (Vector3.Distance(stateController.enemyToChase.transform.position, stateController.ai.transform.position) > (stateController.chaseDist + .2f))
            {
                stateController.ai.speed = stateController.speed;
                stateController.SetState(new ChaseState(stateController));

            }
        }

    }
    public override void Act()
    {
        cooldown -= Time.deltaTime;
        stateController.ai.transform.LookAt(stateController.enemyToChase.transform.position);

        if (!stateController.HasFired())
        {
            stateController.Fire();
            if (!stateController.enemyToChase) stateController.SetState(new PatrolState(stateController));

        }

        //stateController.ai.transform.LookAt(destination);
        //Debug.Log("Start Attacking Brother");
    }





}
