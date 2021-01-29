using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public static float quickfalltime = 0.05f;
    public static float falltime = 0.5f;
    public static float height = 12f;
    public static float width = 6f;
    public GameObject[] blocks;
    private static int heightOfInt = (int)height;
    private static int widthOfInt = (int)width;
    public Transform[,] grid = new Transform[widthOfInt,heightOfInt];
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
        Instantiate(blocks[Random.Range(0,blocks.Length)], transform.position, Quaternion.identity);
    }
}
