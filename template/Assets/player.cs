using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    private float jump_power;
    private float time = 0;
    void Start()
    {
        jump_power = Random.Range(5.0f, 8.0f);
    }

    void Update()
    {
        if (Input.GetButton("Jump"))
            GetComponent<Rigidbody>().velocity = new Vector3(0, jump_power, 0);
        time += Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        SceneManager.LoadScene("Scene1");
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 40, 80, 200, 40), "Jump Power : " + jump_power.ToString());
        GUI.Label(new Rect(Screen.width / 2 - 40, 100, 200, 40), "Time : " + Mathf.RoundToInt(time).ToString());
    }
}