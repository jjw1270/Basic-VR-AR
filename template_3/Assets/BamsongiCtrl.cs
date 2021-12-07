using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiCtrl : MonoBehaviour
{
    public static float timer = 0.0f;
    bool is_shot = false;
    public static bool hit = false;
    public static float distance = 0.0f;
    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(is_shot == true)
        {
            GetComponent<Rigidbody>().AddForce(BamsongiGenerator.wind);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(this.gameObject);
        }
    }

    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
        is_shot = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "target")
            hit = true;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();
        Vector3 collided_position = transform.position;
        distance = collided_position.x * collided_position.x +
            (collided_position.y - 6.5f) * (collided_position.y - 6.5f);
        distance = Mathf.Sqrt(distance);
        //Debug.Log(collided_position);
        Debug.Log(distance);

        if (distance >= 0.0f && distance <= 0.4)
            score = 100;
        else if (distance <= 0.8f)
            score = 90;
        else if (distance <= 1.2f)
            score = 70;
        else if (distance <= 1.6f)
            score = 50;
        else if (distance <= 2.0f)
            score = 30;
        else
            score = 0;
    }
}
