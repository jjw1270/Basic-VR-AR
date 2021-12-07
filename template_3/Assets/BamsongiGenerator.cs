using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongi_prefab;

    public float xWind;
    public float yWind;
    public static Vector3 wind;
    public static float windSpeed;
    private int totScore = 0;
    private int sCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        windF();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && sCount < 5)
        {
            GameObject bamsongi = Instantiate(bamsongi_prefab) as GameObject;
            Ray screen_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 shooting_ray = screen_ray.direction;
            bamsongi.GetComponent<BamsongiCtrl>().Shoot(shooting_ray * 1000);
            wind = new Vector3(xWind, yWind, 0);
            sCount++;
        }
        if (sCount == 5)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }


        if (BamsongiCtrl.hit || BamsongiCtrl.timer >= 2.0f)
        {
            windF();
            BamsongiCtrl.hit = false;
            BamsongiCtrl.timer = -999;
            totScore += BamsongiCtrl.score;
        }
    }

    void windF()
    {
        xWind = Random.Range(-1.0f, 1.0f);
        yWind = Random.Range(-1.0f, 1.0f);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(100, 20, 100, 20), "wind_x : " + xWind.ToString("N2"));
        GUI.Label(new Rect(100, 40, 100, 20), "wind_y : " + yWind.ToString("N2"));
        GUI.Label(new Rect(100, 80, 100, 20), "shot : " + sCount.ToString());
        GUI.Label(new Rect(100, 100, 100, 20), "score : " + totScore.ToString("N2"));
        if (sCount == 5)
            GUI.Label(new Rect(Screen.width / 2 - 30, 80, 100, 20), "Retry : R");
    }
}
