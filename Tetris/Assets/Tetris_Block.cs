using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    private float previousTime;
    public float falltime = 0.8f;
    public static int height = 12;
    public static int width = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3 (-0.3f,0,0);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3 (0.3f,0,0);
        }

        if(Time.time - previousTime > falltime)
        {
            transform.position += new Vector3 (0,-0.3f,0);
            previousTime = Time.time;
        }
    }

    /*bool ValidMove()
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
    }*/
}
