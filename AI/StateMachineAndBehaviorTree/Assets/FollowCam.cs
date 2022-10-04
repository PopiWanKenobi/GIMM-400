using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject subject;
    public Vector3 posOffset;
    public Vector3 rotOffset;
    


    // Start is called before the first frame update
    void Start()
    {
        posOffset = new Vector3(0, 1.3f, 0);
        //rotOffset = new Vector3(10, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if(subject != null)
        {
            transform.position = (subject.transform.position + posOffset);
            transform.rotation = subject.transform.rotation;

        }
    }
}
