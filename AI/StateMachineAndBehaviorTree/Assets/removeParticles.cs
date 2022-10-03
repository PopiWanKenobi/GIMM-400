using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeParticles : MonoBehaviour
{
    public float countdown;
    // Start is called before the first frame update
    void Start()
    {
        countdown = 3;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if(countdown < 0)
        {
            Destroy(gameObject);
        }
    }
}
