using UnityEngine;
using UnityEngine.AI;

public class bAI : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform player;
    bState currentState;

    public bStats stats;

    float _health;
    float _damage;
    float _sight;
    float _speed;
    float _projectileSpeed;
    float _cooldown;


    void Start()
    {
        stats = GetComponent<bStats>();
        _health = stats.health;
        _damage = stats.damage;
        _sight = stats.sight;
        _speed = stats.speed;
        _projectileSpeed = stats.projectileSpeed;
        _cooldown = stats.cooldown;

        GetComponent<bState>();
      
        agent = GetComponent<NavMeshAgent>();
        currentState = new bIdle(gameObject, agent, player);
    }
    private void Update()
    {
        if (_health + _damage > 100) Destroy(gameObject);
        if (_sight + _speed > 10) Destroy(gameObject);
        if (_cooldown != _projectileSpeed * 1.3) Destroy(gameObject);


        currentState = currentState.Process();
    }


}