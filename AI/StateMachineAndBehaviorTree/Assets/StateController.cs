using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StateController : MonoBehaviour, IActor {
    
    //stuff for state machine
    public State currentState;
    public NavMeshAgent ai;
    public Vector3 patrolPoint;
    public GameObject enemyToChase;
    public List<GameObject> enemies;
    public GameObject[] findEnemies;


    //stuff for bullets and particles
    public GameObject bullet;
    public GameObject bulletSpawnPos;
    public AudioClip gunshotSound;
    public GameObject gunshotParticle;
    public GameObject blood;

    //stats
    //health + damage cant be > 100
    //sight + speed cant be 10
    //cooldown must be .25* projectile speed
    public float health;
    public float damage;
    public float speed;
    public float sight;
    public float projectileSpeed;
    private float cooldown;

    
    //magnifiers and distances
    public float chaseDist;
    public float timeTillShot;
    public float projMagnifier;

    public Vector3 GetNextNavPoint()
    {
        // Finds a point to walk to
        float randomZpos = Random.Range(-sight, sight);
        float randomXpos = Random.Range(-sight, sight);

        //CheckEnemiesLeft();
        if(CheckEnemiesLeft())
        {
             patrolPoint = new Vector3(Vector3.zero.x + randomXpos, transform.position.y, Vector3.zero.z + randomZpos);
        }
        else patrolPoint = new Vector3(transform.position.x + randomXpos, transform.position.y, transform.position.z + randomZpos);
        return patrolPoint;
    }

    public bool CheckIfInRange()
    {
        //checks the enemy list to see if any of them are in range
        if (enemies != null)
        {
            CheckEnemiesLeft();
            foreach (GameObject g in enemies)
            {
                if (g != null)
                { //This if needed to be here because g goes null if the enemy dies

                    if (Vector3.Distance(g.transform.position, transform.position) < sight)
                    {
                        if(g != gameObject)
                        {
                        enemyToChase = g;
                        return true;
                        }
                            
                    }
                }

            }
        }
        return false;
    }
    public bool CheckEnemiesLeft()
    {

        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i] == null) enemies.Remove(enemies[i]);
        }
        if (enemies.Count == 2) return true;
        else return false;
    }


    void Start () {

        //populates the findEnemies array by finding objects with tag
        findEnemies = GameObject.FindGameObjectsWithTag("AI");

        //adds everything in the findEnemies array to the enemies list
        //we use a list so we can remove the enemies from it as they die
        foreach(GameObject AI in findEnemies)
        {
            enemies.Add(AI);
        }


        cooldown = projectileSpeed * .25f;
        // checks stats and dies if bad stats returned
        CheckStats();
        if (!CheckStats()) Die();

        // Some basic setup
        ai = GetComponent<NavMeshAgent>();
        ai.speed = speed;
        chaseDist = sight / 2;
        projMagnifier = 2;
        SetState(new PatrolState(this));
	}
	
	void Update () {

        //this needs to run every frame for every state
        currentState.CheckTransitions();
        currentState.Act();

        //this counts down after the player shoots
        if (timeTillShot > 0)
        {
            timeTillShot -= Time.deltaTime;
        }
        else timeTillShot = 0;



    }
    public void SetState(State state)
    {
        //set the enemy state
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
        //creates the bullet, gets the rigid body so we cab add force
        Rigidbody rb = Instantiate(bullet, bulletSpawnPos.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        // sets the bullet damage based on what enemy shoots
        bullet.GetComponent<bulletScript>().bullDamage = damage;
        //adds force
        rb.AddForce(transform.forward * (projectileSpeed * projMagnifier) , ForceMode.Impulse);

        //kicks off the cooldown
        HasFired();
        timeTillShot = cooldown;

        //audio and particles
        AudioSource.PlayClipAtPoint(gunshotSound, bulletSpawnPos.transform.position);
        Instantiate(gunshotParticle, bulletSpawnPos.transform.position, bulletSpawnPos.transform.rotation);

    }

    public bool HasFired()
    {
        // a bool to tell the enemy if they can shoot
        if(timeTillShot > 0)
        {
            return true;
        }
        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
       //enemy checks if it's been hit by a bullet
        if (collision.gameObject.tag == "bullet")
        {
            //adds blood effect
            Instantiate(blood, collision.transform.position, collision.transform.rotation);
            //runs take damage
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        //takes damage
        health -= bullet.GetComponent<bulletScript>().bullDamage;
        //die if health too low
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //die
        Destroy(gameObject);
    }
    
    //======================== STATS ===========================

    //some nonsence to satisfy the interface
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

    // make sure all the state are good
    public bool CheckStats()
    {
        if (Health + Damage > 100) return false;
        if (Sight + Speed > 10) return false;
        if (Cooldown < ProjectileSpeed * .25f) return false;
        else return true;
    }
}
