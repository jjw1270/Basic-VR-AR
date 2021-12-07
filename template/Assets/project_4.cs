using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class project_4 : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D icon = null;
    private int collision_count = 0;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(collision_count > 10)
        {
            SceneManager.LoadScene("Scene1", LoadSceneMode.Single);
            collision_count = 0;
        }
    }
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, Screen.height - 64, 64, 64), icon);
        GUI.Label(new Rect(81, Screen.height - 40, 128, 32), collision_count.ToString());
    }

    void OnCollisionEnter(Collision collision)
    {
        collision_count++;
    }

}
