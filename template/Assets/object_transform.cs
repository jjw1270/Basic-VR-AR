using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_transform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)){
            this.transform.Translate(new Vector3(0.0f,0.0f,3.0f) * Time.deltaTime);//물체의 local좌표 기준 앞(z축)방향
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            float rnd = Random.Range(-0.2f, 0.2f);   //최솟값 최댓값
            this.transform.position += new Vector3(rnd, rnd, rnd);
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            float rnd = Random.Range(0.0f, 360.0f);
            this.transform.rotation = Quaternion.Euler(rnd, 0.0f, 0.0f); //x축방향으로 rnd만큼 회전
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            float rnd = Random.Range(0.5f, 1.5f);
            this.transform.localScale = new Vector3(rnd, rnd, rnd);
        }

        if(Input.GetKey(KeyCode.R)){
            this.transform.Rotate(90.0f * Time.deltaTime, 0.0f, 0.0f);
        }
    }
}
