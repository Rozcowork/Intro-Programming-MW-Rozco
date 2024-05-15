using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMe : MonoBehaviour
{
    //Global Variable
    public static GameObject instance;//instance of a game object 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake() //Called when the scripts are lodaing
    {
        if (instance == null) //Instance has not been set
        {
            
            instance = gameObject; //set the instance to the game object it is attached to
            DontDestroyOnLoad(gameObject);//Prevent the game Object from being destroyed when loading
        }
        else //instance is already set
        {
            
            Destroy(gameObject);//Destroy duplicate instance
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
