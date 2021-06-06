using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class presprot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] preblocks;
    public static int i;
    void Start()
    {
        PreSpawnBlock(); // 隨機生成新方塊
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PreSpawnBlock()
    {
        i= Random.Range(0, preblocks.Length);
        Instantiate(preblocks[i], transform.position, Quaternion.identity); // 將方塊生成至需要的位置
    }

}
