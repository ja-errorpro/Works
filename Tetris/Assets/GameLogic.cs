using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] blocks;
    void Start()
    {
        SpawnBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnBlock()
    {
        if(presport.i == 1)
        {
            Instantiate(blocks[presport.later], transform.position, Quaternion.identity); // 將方塊生成至需要的位置 
            presport.i++;
        }
        else
        {
            ScoreComputing.Update();
            Instantiate(blocks[presport.first], transform.position, Quaternion.identity);//於指定位置生成於"下一個"出現的方塊
        }
    }
}
