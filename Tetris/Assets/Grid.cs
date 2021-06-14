using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static int w = 10; // 設定方塊邊界
    public static int h = 23;

    public static Transform[,] grid = new Transform[w,h]; // 紀錄方塊位置之矩陣
    
    public static Vector2 roundvec2(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool insideborder(Vector2 pos) // 是否越界
    {
        return ((int)pos.x >= 0 && (int)pos.x < w && (int)pos.y >= 0);
    }
}
