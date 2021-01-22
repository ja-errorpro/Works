using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TetrisSport : MonoBehaviour
{    
    private float previousTime;
    public float falltime = 0.5f;
    public static int height = 12;
    public static float width = 5.4f;
    public GameObject rig;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.transform.position += new Vector3 (-0.6f,0,0);
            if(ValidMove() == false) 
                gameObject.transform.position -= new Vector3 (-0.6f,0,0);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameObject.transform.position += new Vector3 (0.6f,0,0);
            if(ValidMove() == false)
                gameObject.transform.position -= new Vector3 (0.6f,0,0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //rotate !
            rig.transform.eulerAngles += new Vector3(0,0,90);
            if(ValidMove() == false)
                rig.transform.eulerAngles -= new Vector3(0,0,90);
        }

        if(Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? falltime / 10 :falltime))
        {
            gameObject.transform.position += new Vector3 (0,-0.6f,0);
            if(ValidMove() == false)
                gameObject.transform.position -= new Vector3 (0,-0.6f,0);
            previousTime = Time.time;
        }
    }

    bool ValidMove()
    {
        foreach(Transform subBlock in rig.transform)
        {
            if( subBlock.transform.position.x < 0 ||
                subBlock.transform.position.x >= width ||
                subBlock.transform.position.y < 0 )
            {
                return false;
            }
        }
        return true;
    }
}