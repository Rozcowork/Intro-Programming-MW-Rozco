using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //GLOBAL VARIABLES
    public int damage; //damage the Boss does
    public PlayerController playerControllerScript;//call the player controller script

    //Enemy Movement
   
    public Transform[] patrolPoints;//List of patrol points
    public float moveSpeed = 8.8f;//boss movement speed
    public int patrolDestination;//patrol destination
    public bool moveBoss = false;// bool set to False so boss does not move
    // Start is called before the first frame update
    void Start()
    {
        damage = 100;//damage the boss does to the player  
    }

    // Update is called once per frame
    void Update()
    {
        if(moveBoss)//if bool is set to true
        {
            EnemyMovement();//call the enemy movement function
        }
    }
        

    private void OnCollisionEnter2D(Collision2D collision) //when the boss collides with an object
    {
        if (collision.gameObject.tag == "Player") //if the player collides with the Boss
        {
            //Debug.Log("enemy hit");
            playerControllerScript.TakeDamage(damage); // call the Player controller script and Take damage
        }

        else if (collision.gameObject.tag == "Lava")// if Lava collides with the Boss
        {
            Destroy(collision.gameObject);//Boss will destroy the Lava
        }

        else if (collision.gameObject.tag == "Enemy")// if enemy collides with the Boss
        {
            Destroy(collision.gameObject);//Boss will destory the Enemy
        }

        else if (collision.gameObject.tag == "Surface")// if Boss collides with the Surface
        {
            Destroy(collision.gameObject);//Boss will destroy the surface
        }
    }

    private void EnemyMovement()// Boss movement to patrol Points
    {
        //Debug.Log("EnemyMovement() called"); 
        if (patrolDestination == 0)//if patrol point 0
        {
            //Debug.Log("Destination 0 is working!");
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);//Boss will move to patrol point 0

            if (Vector3.Distance(transform.position, patrolPoints[0].position) < 0.5) //if at patrol point 0 move to
            {
                patrolDestination = 1;//Boss will move to patrol point 1
            }
        }

        else if (patrolDestination == 1)//if patrol point 1
        {
           // Debug.Log("Destination 1 is working!");
            //Debug.Log("head to next patrol point");
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);//Boss will move to patrol point 1

            if (Vector3.Distance(transform.position, patrolPoints[1].position) < 0.5)//if at patrol point 1 do move to
            {
                patrolDestination = 2;//Boss will move to patrol point 0
            }
        }

        else if (patrolDestination == 2)//if at patrol point 2 
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[2].position, moveSpeed * Time.deltaTime);//Boss will stay at patrol point 2

        }
    }
}
