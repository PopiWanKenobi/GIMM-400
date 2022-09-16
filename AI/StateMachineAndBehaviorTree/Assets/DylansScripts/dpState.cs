using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dpState : MonoBehaviour
{
    public enum STATE
    {
        dpIDLE, dpPATROL, dpATTACK, dpCHASE,
    };

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE name;
    protected EVENT stage;
    protected GameObject npc;
    protected Transform player;
    protected dpState nextState;
    protected NavMeshAgent agent;

    float visDist = 10f;
    float visAngle = 30f;
    float shootDist = 7f;

    public dpState(GameObject _npc, NavMeshAgent _agent, Transform _player)
    {
        npc = _npc;
        agent = _agent;
        stage = EVENT.ENTER;
        player = _player;


    }

    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public dpState Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }
}
