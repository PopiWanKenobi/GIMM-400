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

    public float _cooldown;
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

        _cooldown = 1;
        //Debug.Log("COOLDOWN IS" + _cooldown);
        //Debug.Log("I'm in attack");

        //spawnProjectilePos = GameObject.FindGameObjectWithTag("dpSpawnPos");
      

        base.Enter();
    }

    public override void Tick()
    {
        //Do whatever you want to do in Attack right here 
        //LookAtEnemy();
       /* _cooldown -= Time.deltaTime;
        if(_cooldown <= 0)
        {
            
            _cooldown = 1;
            
        }*/

        Fire();
        //nextState = new dpIdle();
        //stage = EVENT.EXIT;

        //this if statement is the condition to switch from attack to idle


    }
    /*private void LookAtEnemy()
    {
        
    }*/
    private void Fire()
    {
        Debug.Log("Bullet Fired");
        //ourState.SpawnProj();

        StartCoroutine(Shoot());
      //  Quaternion bulletRot = Quaternion.Euler(90f, 0f, 0f);
        
      //  GameObject bullet = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Capsule), spawnProjectilePos, transform.rotation, transform);
        //bullet = transform.rotation;
        /*
        bullet.transform.localScale = bulletScale;
        bullet.transform.rotation = bulletRot;
        Rigidbody rb = bullet.AddComponent<Rigidbody>();
        rb.velocity = bullet.transform.position.normalized * speed * Time.deltaTime;*/

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
