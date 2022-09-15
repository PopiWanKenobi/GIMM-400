using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerInstance : MonoBehaviour
{
    public GameObject[] aiList;

    public GameManagerInstance gameManagerInstance;

    public GameManagerInstance()
    {
        if(gameManagerInstance == null)
        {
            gameManagerInstance = this;
        }
        else
        {
            gameManagerInstance = null;
            Destroy(gameObject);
        }
    }

    private void Start() 
    {
        aiList = GameObject.FindGameObjectsWithTag("AI");

        //implement help check
    }
}
