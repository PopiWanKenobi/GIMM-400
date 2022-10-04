using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    public float bullDamage;
    public float selfDestruct;
    public GameObject hitEffect;


    private void OnCollisionEnter(Collision collision)
    {
        selfDestruct = 3;
        Destroy(gameObject);

        if(hitEffect != null) Instantiate(hitEffect, collision.transform.position, collision.transform.rotation);

    }
    private void Update()
    {
        /*if (selfDestruct > 0)
        {
            selfDestruct -= Time.deltaTime;

        }
        if (selfDestruct < 0)
        {
            Destroy(hitEffect.gameObject);
        }*/
    }
}
