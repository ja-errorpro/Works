using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class presport : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] preblocks;
    public static int first;
    public static int i;
    public static int later;
    void Start()
    {
        i = 1;
        later = Random.Range(0, preblocks.Length);//儲存生成方塊的編號
        PreSpawnBlock(); // 隨機生成新方塊至"下一個"的位置
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PreSpawnBlock()
    {
        first = Random.Range(0, preblocks.Length);//儲存生成方塊的編號
        Instantiate(preblocks[first], transform.position, Quaternion.identity); // 將方塊生成至需要的位置
    }
}
