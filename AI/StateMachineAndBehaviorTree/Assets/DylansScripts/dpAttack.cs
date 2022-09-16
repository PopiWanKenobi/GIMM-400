using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dpAttack : dpState
{
    public GameObject projectilePrefab;
    public GameObject spawnProjectilePos;
    public List<GameObject> enemies;
    public float speed = 7;
    public dpAttack(GameObject _npc, NavMeshAgent _agent, Transform _player) : base(_npc, _agent, _player)
    {
        name = STATE.dpATTACK;
    }

    public override void Enter()
    {
        Debug.Log("I'm in attack");

        spawnProjectilePos = GameObject.FindGameObjectWithTag("dpSpawnPos");
        base.Enter();
    }

    public override void Update()
    {
        //Do whatever you want to do in Attack right here 
        //LookAtEnemy();
        Fire();

        //this if statement is the condition to switch from attack to idle


    }
    /*private void LookAtEnemy()
    {
        
    }*/
    private void Fire()
    {

        GameObject bullet = Instantiate(projectilePrefab, spawnProjectilePos.transform.position, spawnProjectilePos.transform.rotation);
        bullet.transform.position = bullet.transform.position.normalized * speed * Time.deltaTime;
        Debug.Log("Fire has run");
        nextState = new dpIdle(npc, agent, player);
        stage = EVENT.EXIT;
    }
    public override void Exit()
    {
        base.Exit();
    }
}
