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
<<<<<<< HEAD
        if(presport.i==1)
        {
            Instantiate(blocks[presport.later], transform.position, Quaternion.identity); // 將方塊生成至需要的位置 
            presport.i++;
        }
        else
        {
            ScoreComputing.Update();
            Instantiate(blocks[presport.first], transform.position, Quaternion.identity);//於指定位置生成於"下一個"出現的方塊
        }
        
=======
        ScoreComputing.Update();
<<<<<<< HEAD
        Instantiate(blocks[presport.i], transform.position, Quaternion.identity);//於指定位置生成於"下一個"出現的方塊
=======
        Instantiate(blocks[Random.Range(0,blocks.Length)], transform.position, Quaternion.identity);
>>>>>>> a9b4de8e48df11627b822bb16c2f1fd9368bd724
>>>>>>> a78af7bb8c0076ad15a29bdd95f9694e43eb1420
    }
    
}
