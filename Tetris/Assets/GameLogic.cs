﻿using System.Collections;
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
        ScoreComputing.Update();
        Instantiate(blocks[presport.i], transform.position, Quaternion.identity);//於指定位置生成於"下一個"出現的方塊
    }
}
