using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snake : MonoBehaviour
{
    //GLOBAL VARIABLES
    Vector3 dir = Vector3.right;

    //Keep Track of Tail Elements
    List<Transform> tail = new List<Transform>();
    bool ate = false;
    public GameObject tailPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveSnake", 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
       ChangeDirection();
    }

    void MoveSnake()
    {
        Vector3 gap = transform.position;
        transform.Translate(dir);

        if (ate)
        {
            Debug.Log("Ate =" + ate);

            GameObject tailSec = (GameObject)Instantiate(tailPrefab, gap, Quaternion.identity);
            tail.Insert(0, tailSec.transform);
            ate = false;
        }


        if (tail.Count > 0)
        {
            tail.Last().position = gap;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    private void ChangeDirection()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector3.right;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            dir = Vector3.down;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            ate = true;

            //Debug.Log("food eaten");
            Destroy(collision.gameObject);
        }
    }
}
