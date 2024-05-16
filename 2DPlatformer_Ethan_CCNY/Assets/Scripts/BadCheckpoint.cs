using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCheckpoint : MonoBehaviour
{
    public Boss bossScript;// talk to the Boss controller script


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)// when player hits the bad checkpoint trigger
    {
        if(collision.gameObject.tag == "Player")// if Player connects with bad checkpoint
        {
            //Debug.Log("trigger registered");
            bossScript.moveBoss = true;//set the public bool to true
            Destroy(gameObject);//destroy bad chackpoint after use
        }
    }

    
}
