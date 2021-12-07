using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controll : MonoBehaviour
{
    float speed = 5.0f;

    void Update()
    {
        float distance_per_frame = speed * Time.deltaTime;
        float vertical_input = Input.GetAxis("Vertical");
        float horizontal_input = Input.GetAxis("Horizontal");
        Vector3 launch_direction = new Vector3(10,500,300);

        transform.Translate(Vector3.forward * vertical_input * distance_per_frame);
        transform.Translate(Vector3.right * horizontal_input * distance_per_frame);

    }
}
