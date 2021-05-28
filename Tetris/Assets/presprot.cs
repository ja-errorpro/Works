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
        SpawnBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnBlock()
    {
        i= Random.Range(0, preblocks.Length);
        Instantiate(preblocks[i], transform.position, Quaternion.identity);
    }

}
