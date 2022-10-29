using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse 0 - Left Click");
            Debug.Log(Input.mousePosition);

        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Mouse 1 - Right Click");

        }
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("Mouse 2 - Middle Click");

        }
    }
}
