using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour, IActor {

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

    
    //health + damage cant be > 100
    //sight + speed cant be 10
    //cooldown must be 1.3* projectile speed
    public float health;
    public float damage;
    public float speed;
    public float sight;
    public float projectileSpeed;
    public float cooldown;


    public float chaseDist;
    public float timeTillShot;



   
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

        //cooldown = projectileSpeed * 1.3f;

        // checks stats and dies if bad stats returned
        CheckStats();
        if (!CheckStats()) Die();


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
        gameObject.name = gameObject.name + state.GetType().Name;

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
        Instantiate(gunshotParticle, bulletSpawnPos.transform.position, bulletSpawnPos.transform.rotation);

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
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);

    }

    //======================== STATS ===========================
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
    public float Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
    public float Cooldown
    {
        get
        {
            return cooldown;
        }
        set
        {
            cooldown = value;
        }
    }

    public float ProjectileSpeed
    {
        get
        {
            return projectileSpeed;
        }
        set
        {
            projectileSpeed = value;
        }
    }
    public float Sight
    {
        get
        {
            return sight;
        }
        set
        {
            sight = value;
        }
    }

    public bool CheckStats()
    {
        if (Health + Damage > 100) return false;
        if (Sight + Speed > 10) return false;
        if (Cooldown < ProjectileSpeed * 1.3f) return false;
        else return true;
    }
}
