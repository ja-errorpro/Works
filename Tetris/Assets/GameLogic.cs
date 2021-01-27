using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public static float quickfalltime = 0.05f;
    public static float falltime = 0.5f;
    public static int height = 12;
    public static int width = 6;
    public GameObject[] blocks;
    //public Transform[,] grid = new Transform[width,height];
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
