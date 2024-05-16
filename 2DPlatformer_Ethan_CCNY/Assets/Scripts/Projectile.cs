using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //GLOBAL VARIABLES
    public Rigidbody2D projectileRb; //Rigidbody of the projectile
    public float speed = 5; //Speed of the projectile

    //PROJECTILE COUNTDOWN TIMER
    public float projectileLife = 2;//Lifetime of the projectile
    public float projectileCount;//Timer for the projectile

    //flipping launch direction
    public PlayerController playerControllerScript; //Get the script of the Player Controller
    public bool facingLeft; //direction of the projectile

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); //Find the Player controller script
        projectileCount = projectileLife; //timer for the projectile to equal the lifetime of the projectile
        facingLeft = playerControllerScript.facingLeft; //set the direction of the projectile to face the left
        //if (!facingRight)
        //{
        //    transform.Rotate(0, -180, 0);
        //    transform.rotation = Quaternion.Euler(0, 180, 0);
        //    Debug.Log("facingRight = " + facingRight);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime; //reduce the liftime of the projectile
        
        if (projectileCount <= 0) // when the projectile count equals zero destroy the object
        {
            Destroy(gameObject); // when the projectile lifetime reaches 0 destroy the projectile
        }

    }
    
    private void FixedUpdate() // Fixed update is call 50 times per second
    {
        if (facingLeft) //if you are facing left
        {
            projectileRb.velocity = new Vector3(-speed, projectileRb.velocity.y, 0); //Make projectile move left
        }
        else 
        {
            projectileRb.velocity = new Vector3(speed, projectileRb.velocity.y, 0); //Make projectile move right
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // when the projectile collides with object
    {
        if (collision.gameObject.tag == "Lava") //if projectile is colliding with the Lava
        {
            Destroy(collision.gameObject); //When projectile hits Lava the Lava will be destroyed
        }

        else if (collision.gameObject.tag == "Enemy") //if projectile is colliding with the Enemy
        {
            Destroy(collision.gameObject); //When projectile hits the Enemy the Enemy will be destroyed
        }

        Destroy(gameObject); //when the projectile collides with the anything the projectile will destroy itself
    }
}
