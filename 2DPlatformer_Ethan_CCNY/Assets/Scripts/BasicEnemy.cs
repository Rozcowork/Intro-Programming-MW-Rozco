using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    //GLOBAL VARIABLES
    public int damage;//damge the enemy does
    public PlayerController playerControllerScript; //call the player controller script

    //Enemy Movement
    public Transform[] patrolPoints; //List of patrol points
    public float moveSpeed = 4;//Move speed of enemy
    public int patrolDestination;// the destination for the enemy to move

    // Start is called before the first frame update
    void Start()
    {
        damage = 5;//The amount of damage the enemy can do
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();//Call the enemy movement script
    }

    private void OnCollisionEnter2D(Collision2D collision)// when the the enemy collides
    {
        if (collision.gameObject.tag == "Player") // if the player collides with enemy
        {
            //Debug.Log("enemy hit");
            playerControllerScript.TakeDamage(damage); // if the player collides with the enemy call the take damage script from Player controller script
        }
    }

    private void EnemyMovement()//Enemy movement to patrol points
    {
        if (patrolDestination == 0)//if you are patrol destination 0
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);// move to patrol point 0

            if (Vector3.Distance(transform.position, patrolPoints[0].position) < 0.5)//if at patrol point 0 move to
            {
                patrolDestination = 1;// go to patrol point 1
            }
        }

        else if (patrolDestination == 1)//else if you are patrol destination 1
        {
            //Debug.Log("head to next patrol point");
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);// move to patrol point 1

            if (Vector3.Distance(transform.position, patrolPoints[1].position) < 0.5)// if at patrol point 1 move to
            {
                patrolDestination = 0; // go to patrol point 0
            }
        }

    }
}
