using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //using scene library

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
    public void MoveToScene(int sceneID) //Changes each scene by calling the scene ID
    {
        SceneManager.LoadScene(sceneID); //Loads the scene with the scene ID
    }
}
