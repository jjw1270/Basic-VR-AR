using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asf : MonoBehaviour
{
    public Vector3 launch_direction = new Vector3(10,500,300);

    void OnCollisionEnter(Collision coll){
        if(coll.gameObject.name == "Cube")
        {
        GetComponent<Rigidbody>().AddForce(launch_direction);
        GetComponent<AudioSource>().Play();
        }
    }

}