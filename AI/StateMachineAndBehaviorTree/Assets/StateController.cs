using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour {

    public State currentState;
    public NavMeshAgent ai;
    public float walkPointRange;
    public Vector3 patrolPoint;
    public Vector3 target;
    public Vector3 destination;
    public GameObject enemyToChase;
    public GameObject[] enemies;

    public Transform rotation;
    public GameObject bullet;
    public GameObject bulletSpawnPos;
    public float projMagnifier;
    public AudioClip gunshotSound;
    public GameObject gunshotParticle;
    public GameObject blood;

    private GameObject particle;

    public float health;
    public float damage;
    public float speed;
    public float cooldown;
    public float timeTillShot;
    public float projectileSpeed;
    public float sight;
    public float chaseDist;

    //health + damage cant be > 100
    //sight + speed cant be 10
    //cooldown must be 1.3* projectile speed

    public Vector3 GetNextNavPoint()
    {

        float randomZpos = Random.Range(-sight, sight);
        float randomXpos = Random.Range(-sight, sight);

        patrolPoint = new Vector3(transform.position.x + randomXpos, transform.position.y, transform.position.z + randomZpos);
        return patrolPoint;

        // navPointNum = (navPointNum + 1) % navPoints.Length;
        // return navPoints[navPointNum].transform;
    }

    public bool CheckIfInRange()
    {
        //enemies = GameObject.FindGameObjectsWithTag("AI");
        if (enemies != null)
        {
            foreach (GameObject g in enemies)
            {
                if (g != null) {

                    if (Vector3.Distance(g.transform.position, transform.position) < sight)
                    {

                        enemyToChase = g;

                        return true;


                    }
                }

            }
        }
        return false;
    }

	void Start () {

        ai = GetComponent<NavMeshAgent>();
        ai.speed = speed;
        chaseDist = sight / 2;
        projMagnifier = 2;
        //navPoints = GameObject.FindGameObjectsWithTag("navpoint");
        SetState(new PatrolState(this));
	}
	
	void Update () {
        currentState.CheckTransitions();
        currentState.Act();

        if (timeTillShot > 0)
        {
            timeTillShot -= Time.deltaTime;
        }
        else timeTillShot = 0;



    }
    public void SetState(State state)
    {
        if(currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = state;
        gameObject.name = "AI agent in state " + state.GetType().Name;

        if(currentState != null)
        {
            currentState.OnStateEnter();
        }
    }

    public void Fire()
    {
        Rigidbody rb = Instantiate(bullet, bulletSpawnPos.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        bullet.GetComponent<bulletScript>().bullDamage = damage;
        rb.AddForce(transform.forward * (projectileSpeed * projMagnifier) , ForceMode.Impulse);


        HasFired();
        timeTillShot = cooldown;

        //audio and particles
        AudioSource.PlayClipAtPoint(gunshotSound, bulletSpawnPos.transform.position);
        particle = Instantiate(gunshotParticle, bulletSpawnPos.transform.position, bulletSpawnPos.transform.rotation);




    }

    public bool HasFired()
    {
        if(timeTillShot > 0)
        {
            return true;
        }
        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
       

        if (collision.gameObject.tag == "bullet")
        {
            Instantiate(blood, collision.transform.position, collision.transform.rotation);

            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        health -= bullet.GetComponent<bulletScript>().bullDamage;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
