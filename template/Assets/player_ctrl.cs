using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class player_ctrl : MonoBehaviour
{
    public GameObject goal = null;
    private float power;
    public float power_plus = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject game_object = GameObject.Instantiate(this.goal) as GameObject;
        game_object.transform.position = new Vector3(Random.Range(5.0f, 10.0f), Random.Range(-3.0f, 1.0f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x == 0 || this.transform.position.y == 0)
        { //ĳ���� �������� �Ұ���
            if (Input.GetMouseButton(0))
            {
                power += power_plus * Time.deltaTime;  //���콺 ���� ��ư�� ������ �ִ� ���� ���� ����
            }
            if (Input.GetMouseButtonUp(0))
            {
                this.GetComponent<Rigidbody>().AddForce(new Vector3(power, power, 0));
                power = 0.0f;
            }
        }
        if(this.transform.position.y < -5.0f || Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene("Scene1"); //ĳ���Ͱ� ���� ���� �Ʒ��� �������ų�, ���콺 ������ ��ư�� ������ Scene �����
        }
    }
}
