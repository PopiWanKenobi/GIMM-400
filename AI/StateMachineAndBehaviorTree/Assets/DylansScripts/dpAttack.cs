using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dpAttack : dpState
{
    private GameObject projectilePrefab;
    private Vector3 spawnProjectilePos;
    public List<GameObject> enemies;
    private Vector3 bulletScale;
    public float speed = 7;

    public dpState ourState;

    public float _cooldown = 1;
    //public dpAI ai;
    public dpAttack()
    {
        name = STATE.dpATTACK;
    }
    

    public override void Enter()
    {
        ourState = GetComponent<dpState>();
        //_cooldown = stats.cooldown;
        //bulletScale = new Vector3(.08f, .08f, .08f);
        //spawnProjectilePos = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z + 3f);

        //_cooldown = 1;
        //Debug.Log("I'm in attack");

        //spawnProjectilePos = GameObject.FindGameObjectWithTag("dpSpawnPos");
      

        base.Enter();
    }

    public override void Tick()
    {
        //Do whatever you want to do in Attack right here 
        //LookAtEnemy();
        //Debug.Log("COOLDOWN IS" + _cooldown);

        _cooldown -= Time.deltaTime;
        if(_cooldown <= 0)
        {
            Fire();
            _cooldown = 7.8f;
            
        }

    }

    private void Fire()
    {
        SpawnProj();
        //Shoot();
        //Debug.Log("Bullet Fired");


    }

    IEnumerator Shoot()
    {
        SpawnProj();
        yield return new WaitForSeconds(5f);
    }
    public override void Exit()
    {
        base.Exit();
    }
}
