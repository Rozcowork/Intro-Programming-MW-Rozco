using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    //GLOBAL VARIABLES
    public int damage;
    public PlayerController playerControllerScript;

    //Enemy Movement
    public Transform[] patrolPoints;
    public float moveSpeed = 4;
    public int patrolDestination;

    // Start is called before the first frame update
    void Start()
    {
        damage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("enemy hit");
            playerControllerScript.TakeDamage(damage);
        }
    }

    private void EnemyMovement()
    {
        if (patrolDestination == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, patrolPoints[0].position) < 0.5)
            {
                patrolDestination = 1;
            }
        }

        else if (patrolDestination == 1)
        {
            //Debug.Log("head to next patrol point");
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, patrolPoints[1].position) < 0.5)
            {
                patrolDestination = 0;
            }
        }

    }
}
