using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5.0f);  //5�� �ڿ� �� ��ü ����
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Random.Range(-6.0f, -4.0f) * Time.deltaTime, 0, 0);
    }
}
