using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI foodScoreText; //Text on UI will be affected
    public int foodScore = 0; //Public integer initial score of zero on UI

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foodScoreText.text = "Score: " + foodScore; //Add a score to the food score UI
    }

    public void FoodEaten() // Update score
    {
        foodScore++; //Increase food score to add one to previous number in short hand
    }

    public void RottenFoodEaten() // Update Score
    {
        foodScore--; // Decrease food score to subtract one from previous number in short hand
    }
}
