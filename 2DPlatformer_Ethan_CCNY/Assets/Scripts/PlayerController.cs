using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //GLOBAL VARIABLES
    public Rigidbody2D playerBody; //Body of the Player

    public float playerSpeed = 0.005f; //speed of the Player
    public float jumpForce = 400; // force applied to the jump
    public bool isJumping = false; // At start the player is not jumping

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Jump();
    }
    
    private void MovePlayer()
    {
        Vector3 newPos = transform.position; //Current postition of the player

        if (Input.GetKey(KeyCode.A)) //if you press "A" change position
        {
            //Debug.Log("A pressed");
            newPos.x -= playerSpeed; //when "A" is pressed go left 
        }
        else if (Input.GetKey(KeyCode.D)) //if you press "D" change position
        {
            //Debug.Log("D pressed");
            newPos.x += playerSpeed; //when "D" is pressed go right
        }

        transform.position = newPos; //close the loop of the if statements to move player
    }
    
    private void Jump()
    {
        if (!isJumping && Input.GetKeyDown(KeyCode.Space)) // if isJumping is true and you press "Spacebar" change position
        {
            playerBody.AddForce(new Vector3(playerBody.velocity.x, jumpForce, 0)); //Add jump force to the player to change new vertical position
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // check if player collides with ground
    {
        if (collision.gameObject.tag == "Surface") // when player collides with surface allow player to jump again
        {
            isJumping = false; //set isJumping Boolean to False to allow player to jump again
        }
    }
}