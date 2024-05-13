using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMe : MonoBehaviour
{
    //Global Variable
    public static GameObject instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if (instance == null)
        {
            Debug.Log("Game Manager not destroyed.");
            instance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("Duplicate Audio Manager Destroyed");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
