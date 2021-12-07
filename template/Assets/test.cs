using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    int value = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.U))
        {
            Debug.Log(Input.mousePosition);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            value += 1;
            Debug.Log("Space " + value);
        }
        if (Input.GetMouseButtonUp(1))
        {
            value -= 1;
            Debug.Log("Mouse " + value);
        }
    }
}
