using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TetrisSport : MonoBehaviour
{    
    public Vector3 rotationPoint;
    private float previousTime;
    public float falltime = 0.5f;
    public static int height = 12;
    public static int width = 6;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3 (-0.6f,0,0);
            if(!ValidMove())
                transform.position -= new Vector3 (-0.6f,0,0);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3 (0.6f,0,0);
            if(!ValidMove())
                transform.position -= new Vector3 (0.6f,0,0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //rotate !
            transform.RotateAround(transform.TransformPoint(rotationPoint),new Vector3(0,0,1), 90);
            if (!ValidMove())
                transform.RotateAround(transform.TransformPoint(rotationPoint),new Vector3(0,0,1), -90);
        }

        if(Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? falltime / 10 :falltime))
        {
            transform.position += new Vector3 (0,-0.6f,0);
            if(!ValidMove())
                transform.position -= new Vector3 (0,-0.6f,0);
            previousTime = Time.time;
        }
    }

    bool ValidMove()
    {
        foreach(Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if(roundedX < 0 || roundedX >=width || roundedY < 0 || roundedY >= height)
            {
                return false;
            }
        }
        return true;
    }
}