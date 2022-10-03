using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    public float bullDamage;
    public float selfDestruct = 3;


    private void OnCollisionEnter(Collision collision)
    {
        selfDestruct -= Time.deltaTime;
        Destroy(gameObject);
    }
}
