using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dpState : MonoBehaviour
{

    public STATE name;
    public EVENT stage;
    //protected GameObject npc;
    protected Transform player;
    public dpState nextState;
    public dpState currentState;
    // protected NavMeshAgent agent;
    public GameObject bulletPrefab;


    public void Start()
    {
        name = STATE.dpIDLE;
    }
    public enum STATE
    {
        dpIDLE, dpPATROL, dpATTACK, dpCHASE,
    };

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };




    public dpState()
    {
        //npc = _npc;
        //agent = _agent;
        stage = EVENT.ENTER;
        //player = _player;
        name = STATE.dpIDLE;


    }
    public dpState(STATE ns)
    {
        if(ns == STATE.dpATTACK)
        {
            dpAttack attack = new dpAttack();
            currentState = attack;
        }
    }
    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Tick() { 
        stage = EVENT.UPDATE;
        currentState.Tick();
    }
    public virtual void Exit() { stage = EVENT.EXIT; }
    
    public dpState Process()
    {
        
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE)
        {
            Debug.Log("Stage: " + stage);
            Debug.Log("CurrentState: " + currentState.name);
            Tick();
        }
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }
    public void SpawnProj()
    {
        Debug.Log("BULLET SPAWNED");
        

        //Rigidbody rb = bullet.GetComponent<Rigidbody>();
        GameObject bullet = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Capsule), Vector3.one, Quaternion.identity);
        Rigidbody rb = bullet.AddComponent<Rigidbody>();
        Debug.Log(player.position.x);
        bullet.transform.position = player.position;
        bullet.transform.rotation = player.rotation;

        rb.velocity = bullet.transform.position.normalized * 1f * Time.deltaTime;
    }

}
