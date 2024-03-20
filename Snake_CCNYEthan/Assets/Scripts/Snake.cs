using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snake : MonoBehaviour
{
    //GLOBAL VARIABLES
    public Vector3 dir = Vector3.right; //Snake will move right on start

    //Keep Track of Tail Elements
    List<Transform> tail = new List<Transform>(); //Holding the List of the Tail Prefab
    bool ate = false; //Check to see if you ate food or not false means you have not ate anything 
    bool rottenfood = false; // Check to see if you ate food or not false means you have not ate anything 
    public GameObject tailPrefab; //Grab the Tail Prefab script to add to it
    public SceneChanger mySceneChanger; //Grab the SceneChanger Script to control the scene
    public GameManager myManager; //Grab the Game Manager script to control FoodScore UI


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveSnake", 0.1f, 0.1f); //After 0.1 second snake will move
    }

    // Update is called once per frame
    void Update()
    {
       ChangeDirection(); //Grab directional change code
    }

    void MoveSnake() //Move snake and reorders snake body list
    {
        Vector3 gap = transform.position; //Get Current Position
        transform.Translate(dir); //Move the Snake head

        if (ate) //Ate food and need to increase snake length
        {

            GameObject tailSec = (GameObject)Instantiate(tailPrefab, gap, Quaternion.identity); //Spawn snake body at the current position
            tail.Insert(0, tailSec.transform); //Add new body prefab to the list
            ate = false; //Set the boolean to false
        }


        else if (tail.Count > 0) //If the list is not empty
        {
            tail.Last().position = gap; //Get the last transform of the snake body and set it to the current position
            tail.Insert(0, tail.Last()); //Add the last snake body to the gap at the front of the list
            tail.RemoveAt(tail.Count - 1); //Remove the extra snake body
        }

        else if (rottenfood) // Ate Rottenfood and try to make snake size decrease
        {
            rottenfood = false; // Set the boolean to false
            tail.RemoveAt(tail.Count - 1); // Try and make snake size decrease but it only effects score
        }
    }
    //Change Direction
    private void ChangeDirection() 
    {
        if (Input.GetKey(KeyCode.LeftArrow)) //Pressing the Left Arrow key
        {
            dir = Vector3.left; //Snake moves left
        }
        else if (Input.GetKey(KeyCode.RightArrow)) //Pressing the Right Arrow key
        {
            dir = Vector3.right; //Snake moves right
        }
        else if (Input.GetKey(KeyCode.UpArrow)) //Pressing the Up Arrow key
        {
            dir = Vector3.up; //Snake moves up
        }
        else if (Input.GetKey(KeyCode.DownArrow)) //Presing the Down Arrow key
        {
            dir = Vector3.down; //Snake moves down
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //On the trigger of the snake food gets eaten
    {
        if (collision.gameObject.tag == "Food") //when snake collides with food it gets eaten
        {
            ate = true; //set boolean to true after food is eaten

            //Debug.Log("food eaten");
            Destroy(collision.gameObject); //when food is eaten by Snake it gets destroyed
            myManager.FoodEaten(); //Grab game manager food score UI to make UI score go up
        }
        else if (collision.gameObject.tag == "Wall") // when snake collides with wall go to game over scene
        {
            mySceneChanger.MoveToScene(2); // move to scene 2 when snake collides with wall
        }
        else if (collision.gameObject.tag == "Rotten Food") //when snake collides with rotten food it gets eaten
        {
            rottenfood = true; //set bolean to true after rotten food is eaten

            Destroy(collision.gameObject); //when rotten food is eaten by Snake it gets destroyed
            myManager.RottenFoodEaten(); // Grab game manager food score UI to make the Score go Down
        }
        else if (myManager.foodScore == -1) // When game score goes into the negative end the game
            {
                mySceneChanger.MoveToScene(2); // move to scene 2 when the score goes negative
            }
    }
}
