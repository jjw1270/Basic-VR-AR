using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_control : MonoBehaviour
{
    public struct CreationInfo
    {
        public Block.TYPE block_type;
        public int max_count;
        public float height;
        public int current_count;
    };

    public CreationInfo previous_block;
    public CreationInfo current_block;
    public CreationInfo next_block;

    public int level = 0;

    private void ClearNextBlock(ref CreationInfo block)
    {
        block.block_type = Block.TYPE.FLOOR;
        block.max_count = 15;
        block.height = 0.0f;
        block.current_count = 0;
    }

    public void Initialize()
    {
        ClearNextBlock(ref previous_block);
        ClearNextBlock(ref current_block);
        ClearNextBlock(ref next_block);
    }

    int timer_remainder;

    private void UpdateLevel(ref CreationInfo current, CreationInfo previous)
    {
        timer_remainder = GameObject.FindGameObjectWithTag("Player").GetComponent<player_control>().timer_remainder;
        //Debug.Log(timer_remainder);
        switch (previous.block_type)
        {
            case Block.TYPE.FLOOR:
                current.block_type = Block.TYPE.HOLE;

                if(timer_remainder >= 0 && timer_remainder < 30)
                    current.max_count = Random.Range(1, 3);
                else if(timer_remainder >= 30 && timer_remainder < 60)
                    current.max_count = Random.Range(2, 4);
                else if(timer_remainder >= 60 && timer_remainder < 75)
                    current.max_count = Random.Range(1, 3);

                current.height = previous.height;

                break;
            case Block.TYPE.HOLE:
                current.block_type = Block.TYPE.FLOOR;

                if (timer_remainder >= 0 && timer_remainder < 15)
                {
                    current.max_count = Random.Range(9, 11);
                    current.height = 0;
                }
                else if (timer_remainder >= 15 && timer_remainder < 30)
                {
                    current.max_count = Random.Range(8, 10);
                    current.height = Random.Range(-1.0f, 1.0f);
                }
                else if (timer_remainder >= 30 && timer_remainder < 45)
                {
                    current.max_count = Random.Range(7, 9);
                    current.height = Random.Range(-2.0f, 2.0f);
                }
                else if (timer_remainder >= 45 && timer_remainder < 60)
                {
                    current.max_count = Random.Range(6, 8);
                    current.height = Random.Range(-2.0f, 2.0f);
                }
                else if (timer_remainder >= 60 && timer_remainder < 75)
                {
                    current.max_count = Random.Range(5, 8);
                    current.height = Random.Range(-1.0f, 1.0f);
                }

                break;
        }
    }

    public void UpdateStatus()
    {
        current_block.current_count++;

        if(current_block.current_count >= current_block.max_count)
        {
            previous_block = current_block;
            current_block = next_block;

            ClearNextBlock(ref next_block);
            UpdateLevel(ref next_block, current_block);
        }
    }
}
public class Block
{
    public enum TYPE
    {
        NONE = -1,
        FLOOR = 0,
        HOLE,
        NUM,
    };
};

