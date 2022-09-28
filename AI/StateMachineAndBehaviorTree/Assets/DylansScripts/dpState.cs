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
    public GameObject bulletPrim;
    public GameObject dylanAI;
    public Vector3 gunOffset;
    public GameObject bulletSpawnPos;


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

        
        dylanAI = GameObject.Find("DylanAI");
        bulletSpawnPos = GameObject.Find("dpSpawnPos");
        
        //bulletSpawnPos = new Vector3(dylanAI.transform.position.x + .1f, dylanAI.transform.position.y + 1.3f, dylanAI.transform.position.z + .8f);
        //bulletSpawnPos = dylanAI.transform.position ;
        bulletPrim = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        bulletPrim.transform.localScale = new Vector3(.08f, .08f, .08f);
        bulletPrim.transform.localRotation = Quaternion.Euler(90, 0, 0);

        GameObject bullet = Instantiate(bulletPrim, bulletSpawnPos.transform.position, bulletSpawnPos.transform.rotation);
        Rigidbody rb = bullet.AddComponent<Rigidbody>();
        bullet.AddComponent<bulletScript>();

        //rb.velocity = bullet.transform.position.normalized * 1f * Time.deltaTime;
    }

}
