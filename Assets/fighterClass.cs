using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fighterClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("hello world");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            print("up");

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            print("down");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            print("Right");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            print("left");
        }
    }
}
