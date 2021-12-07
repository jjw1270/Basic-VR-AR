using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject pf_wall;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            transform.position = new Vector3(5, Random.Range(-3.0f, 4.0f), 0);
            Instantiate(pf_wall, transform.position, transform.rotation);
            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
