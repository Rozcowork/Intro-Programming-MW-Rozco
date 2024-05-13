using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //GLOBAL VARIABLES
    public Rigidbody2D playerBody; //Body of the Player

    public float playerSpeed = 0.008f; //speed of the Player
    public float jumpForce = 400; // force applied to the jump
    public bool isJumping = false; // At start the player is not jumping

    //Player Health
    public int maxHealth = 20; //maximum health in a integer
    public int currentHealth; //current health of your player
    public HealthBar healthbarScript; //call the health bar script to change the Health bar UI

    //"Flip" direction variables
    public bool flippedLeft; //keep track of which way our sprite is Currently facing
    public bool facingLeft; //keeps track of which way our sprite Should be facing

    //play sound effects
    public AudioSource lavaRockAudio;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; //set current health to the Max at the start of the game
        healthbarScript.SetMaxHealth(maxHealth); //call the HealthBar script to change the UI health
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(); //call MovePlayer constantly
        Jump(); //call Jump constantly
    }
    
    private void MovePlayer() //this private void is to move the player
    {
        Vector3 newPos = transform.position; //Current postition of the player

        if (Input.GetKey(KeyCode.A)) //if you press "A" change position
        {
            //Debug.Log("A pressed");
            newPos.x -= playerSpeed; //when "A" is pressed go left 
            facingLeft = true; //set the boolean to true when facing left
            Flip(facingLeft); //call the Flip Facing left void
        }
        else if (Input.GetKey(KeyCode.D)) //if you press "D" change position
        {
            //Debug.Log("D pressed");
            newPos.x += playerSpeed; //when "D" is pressed go right
            facingLeft = false; //set the boolean to false when facing right
            Flip(facingLeft); //call the Flip Facing left void
        }

        transform.position = newPos; //close the loop of the if statements to move player
    }
    
    private void Jump() //this private void is for the Player to Jump
    {
        if (!isJumping && Input.GetKeyDown(KeyCode.Space)) // if isJumping is true and you press "Spacebar" change position
        {
            playerBody.AddForce(new Vector3(playerBody.velocity.x, jumpForce, 0)); //Add jump force to the player to change new vertical position
            isJumping = true; //change the boolean to true if the player is jumping
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // check if player collides with ground
    {
        if (collision.gameObject.tag == "Surface") // when player collides with surface allow player to jump again
        {
            isJumping = false; //set isJumping Boolean to False to allow player to jump again
        }

        if (collision.gameObject.tag == "Lava") //check if player collides with Lava
        {
            lavaRockAudio.Play();
            TakeDamage(2); //make player take 2 damage when colliding with Lava
        }
    }

    public void TakeDamage(int damage) //if you take damage the number you recieve will effect the health bar
    {
        currentHealth -= damage; //shorthand to subtract the current health from the damage you recieve
        healthbarScript.SetHealth(currentHealth); //set health to the new current health after taking damage
    }

    void Flip(bool facingLeft) //this void flips the character
    {
        //Debug.Log("Flip() called. facingRight = " + facingRight);
        if (facingLeft && !flippedLeft) //if facingLeft is true and the flippedLeft is false rotate the player
        {
            transform.Rotate(0, -180, 0); //change the way the player is facing to the left 
            flippedLeft = true; //set the boolean to true
        }

        if (flippedLeft && !facingLeft) //if flipped Left is true and the facingLeft is false rotate the player
        {
            transform.Rotate(0, 180, 0); //change the way the player is facing to the right
            flippedLeft = false; //set the booolean to false
        }
    }
}
