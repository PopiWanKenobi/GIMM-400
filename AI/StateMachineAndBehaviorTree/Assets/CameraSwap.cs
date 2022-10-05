using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraSwap : MonoBehaviour
{
    public GameObject[] findCameras;
    public List<Camera> cameras;
    public Camera currentCamera;
    public int cameraNum;

    // Start is called before the first frame update
    public void Start()
    {
        findCameras = GameObject.FindGameObjectsWithTag("cam");

        foreach(GameObject cam in findCameras)
        {
            cameras.Add(cam.GetComponentInChildren<Camera>());
        }
        currentCamera = cameras[5];
        currentCamera.enabled = true;
    }

    public void NextCamera()
    {
        if (currentCamera != null)
        {
            currentCamera.enabled = false;
        }
        cameraNum += 1;
        if (cameraNum >= cameras.Count) cameraNum = 0;
        currentCamera = cameras[cameraNum];
        currentCamera.enabled = true;
    }



    public void RemoveCam()
    {
        for (int i = cameras.Count - 1; i >= 0; i--)
        {
            if (cameras[i] == null) cameras.Remove(cameras[i]);
            
            //cameraNum++;
            //if (cameraNum > cameras.Count) cameraNum = 0;
            //currentCamera = cameras[cameraNum];
        }
    }
    // Update is called once per frame
    void Update()
    {


        if (currentCamera == null) 
        {
            RemoveCam();

            NextCamera();
        }

        if (Input.GetKeyDown("space"))
        {
            RemoveCam();

            NextCamera();
            
        }
    }


}
