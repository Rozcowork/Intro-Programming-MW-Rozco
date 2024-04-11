using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    //Global Variables
    public GameObject dropdown;


    // Start is called before the first frame update
    void Start()
    {
        dropdown.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ChooseMode()
    {
        dropdown.SetActive(true);
    }

    public void ExitChooseMode()
    {
        dropdown.SetActive(false);
    }

}
