using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    public static float ACCELERATTON = 10.0f;
    public static float SPEED_MIN = 4.0f;
    public static int SPEED_MAX;
    public static float JUMP_HEIGHT_MAX = 3.0f;
    public static float JUMP_POWER_REDUCE = 0.5f;
    public static float FAIL_LIMIT = -5.0f;

    bool timeActive = true;

    public enum STEP
    {
        NONE = -1,
        RUN = 0,
        JUMP,
        MISS,
        NUM,
    };

    public STEP step = STEP.NONE;
    public STEP next_step = STEP.NONE;

    public float step_timer = 0.0f;
    private bool is_landed = false;
    //private bool is_collided = false;
    private bool is_key_released = false;

    private void Start()
    {
        next_step = STEP.RUN;
    }
    private void CheckLanded()
    {
        is_landed = false;

        do
        {
            Vector3 current_position = transform.position;
            Vector3 down_position = current_position + Vector3.down * 1.0f;

            RaycastHit hit;
            if (!Physics.Linecast(current_position, down_position, out hit))
                break;

            if (step == STEP.JUMP)
            {
                if (step_timer < Time.deltaTime * 3.0f)
                    break;
            }
            is_landed = true;
        } while (false);
    }

    float timer;
    public int timer_remainder;

    void Update()
    {
        if (timeActive)
        {
            timer += Time.deltaTime;
            timer_remainder = Mathf.RoundToInt(timer) % 75;
        }

        if (timer_remainder >= 0 && timer_remainder < 15)
            SPEED_MAX = 5;
        else if (timer_remainder >= 15 && timer_remainder < 30)
            SPEED_MAX = 6;
        else if (timer_remainder >= 30 && timer_remainder < 45)
            SPEED_MAX = 5;
        else if (timer_remainder >= 45 && timer_remainder < 60)
            SPEED_MAX = 9;
        else if (timer_remainder >= 60 && timer_remainder < 75)
            SPEED_MAX = 8;

        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        CheckLanded();
        
        switch (step)
        {
            case STEP.RUN:
            case STEP.JUMP:
                if (transform.position.y < FAIL_LIMIT)
                    next_step = STEP.MISS;
                break;
        }

        step_timer += Time.deltaTime;

        if (next_step == STEP.NONE)
        {
            switch (step)
            {
                case STEP.RUN:
                    if (!is_landed)
                    {
                    }
                    else if (Input.GetMouseButtonDown(0))
                        next_step = STEP.JUMP;
                    break;
                case STEP.JUMP:
                    if (is_landed)
                        next_step = STEP.RUN;
                    break;
            }
        }

        while (next_step != STEP.NONE)
        {
            step = next_step;
            next_step = STEP.NONE;

            switch (step)
            {
                case STEP.JUMP:
                    velocity.y = Mathf.Sqrt(2.0f * 9.8f * JUMP_HEIGHT_MAX);
                    is_key_released = false;
                    break;
            }

            step_timer = 0.0f;
        }
        switch (step)
        {
            case STEP.RUN:
                velocity.x += ACCELERATTON * Time.deltaTime;
                if (Mathf.Abs(velocity.x) > SPEED_MAX)
                    velocity.x = SPEED_MAX;
                break;

            case STEP.JUMP:
                do
                {
                    if (!Input.GetMouseButtonUp(0))
                        break;
                    if (is_key_released)
                        break;
                    if (velocity.y <= 0.0f)
                        break;

                    velocity.y *= JUMP_POWER_REDUCE;
                    is_key_released = true;
                }while(false);
                break;

            case STEP.MISS:
                velocity.x -= player_control.ACCELERATTON * Time.deltaTime;
                if(velocity.x <= 0.0f)
                {
                    velocity.x = 0.0f;
                    timeActive = false;
                    Application.Quit();
                }
                break;
        }

        GetComponent<Rigidbody>().velocity = velocity;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 40, 80, 200, 20), "경과시간 : " + timer.ToString());
        //GUI.Label(new Rect(Screen.width / 2 - 40, 60, 200, 20), "MAX_Speed : " + SPEED_MAX.ToString());
    }
}
