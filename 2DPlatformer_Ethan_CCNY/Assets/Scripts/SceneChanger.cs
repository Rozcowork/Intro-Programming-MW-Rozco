using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //use Scene Management Library

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToScen(int sceneID) //change scenes to match ID
    {
        SceneManager.LoadScene(sceneID); //use the scene manager to load the next scene
    }
}
