using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_cube : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject game_object = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            game_object = GameObject.Find("Cube");
            Destroy(game_object);
        }
    }
}