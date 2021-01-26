using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TetrisSport : MonoBehaviour
{    
    bool movable = true;
    private float time = 0;
    private float quickfalltime = 0.05f;
    public float falltime = 0.5f;
    public static float height = 12f;
    public static float width = 5.4f;
    public GameObject rig;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movable)
        {
            time += 1 * Time.deltaTime;
            if(time > quickfalltime && Input.GetKey(KeyCode.DownArrow))
            {
                gameObject.transform.position += new Vector3 (0,-0.6f,0);
                time = 0;
                if(ValidMove() == false) 
                    gameObject.transform.position -= new Vector3 (0,-0.6f,0);
                //Debug.Log(gameObject.transform.position);
            }
            else if(time > falltime)
            {
                gameObject.transform.position += new Vector3 (0,-0.6f,0);
                time = 0;
                if(ValidMove() == false) 
                    gameObject.transform.position -= new Vector3 (0,-0.6f,0);
                //Debug.Log(gameObject.transform.position);
            }
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
                print(subBlock.name);
                Debug.Log(subBlock.transform.position.x);
                Debug.Log(subBlock.transform.position.y);
                return false;
            }
        }
        return true;
    }
}