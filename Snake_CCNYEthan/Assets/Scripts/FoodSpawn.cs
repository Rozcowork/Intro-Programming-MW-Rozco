using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{

    //GLOBAL VARIABLES
    public GameObject foodPrefab; // Grab the Food Prefab
    public GameObject rottenfoodPrefab; //Grab the Rotten Food Prefab

    //Border Positions
    public Transform wallTop; //Find the position of the top wall
    public Transform wallBottom; //Find the position of the bottom wall
    public Transform wallLeft; //Find the position of the left wall
    public Transform wallRight; //Find the position of the right wall

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 3, 4); // Make the first food spawn at 3 seconds and every 4 seconds after
        InvokeRepeating("RottenFoodSpawn", 5, 10); // Make the first rotten food spawn at 5 seconds and ever 10 seconds after
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()// spawn food randomly
    {
        //Debug.Log("Spawn Called");

        int xPos = (int)Random.Range(wallLeft.position.x, wallRight.position.x); //Find a random position between the Left and right walls to spawn food
        int yPos = (int)Random.Range(wallTop.position.y, wallBottom.position.y); //Find a random position between the Top and bottom walls to spawn food

        Instantiate(foodPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity); //Spawn food in previously found position
    }
    void RottenFoodSpawn()// spawn rotten food randomly
    {
        int xPos = (int)Random.Range(wallLeft.position.x + 10, wallRight.position.x - 10); //Find a random position between the Left and right walls to spawn rotten food
        int yPos = (int)Random.Range(wallTop.position.y - 10, wallBottom.position.y + 10); //Find a random position between the Top and bottom walls to spawn rotten food

        Instantiate(rottenfoodPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity); //Spawn rotten food in previously found position
    }
}
