using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // use scene library

public class SceneChanger : MonoBehaviour
{
    //Global Variables
    public int sceneNumber;
    //0 = Start Scene
    //1 = Main Scene
    //2 = End Scene

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (sceneNumber == 0) //we are in the start scene
        {
            StartSceneControls(); //call start scene controls
        }
       else if (sceneNumber == 1) //we are in the main scene
        {
            MainSceneControls(); //call main scene controls
        }
       else if (sceneNumber == 2) //we are in the End scene
        {
            EndSceneControls(); //call end scene controls
        }
    }
    public void StartSceneControls()
    {
        if (Input.GetKeyDown(KeyCode.Return))//if the enter key is pressed go to the mainscene
        {
            SceneManager.LoadScene("MainScene");
        }
    }
    public void MainSceneControls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("EndScene");
        }
    }
    public void EndSceneControls()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("StartScene");
        }
    }
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
