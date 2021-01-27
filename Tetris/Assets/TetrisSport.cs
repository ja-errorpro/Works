using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TetrisSport : MonoBehaviour
{    
    bool movable = true;
    public static float time = 0;
    public GameObject rig;
    GameLogic gameLogic; 
    public Vector3 rotationPoint;
    void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movable)
        {
            time += 1 * Time.deltaTime;
            if(time > GameLogic.quickfalltime && Input.GetKey(KeyCode.DownArrow))
            {
                gameObject.transform.position += new Vector3 (0,-0.6f,0);
                time = 0;
                if(!ValidMove()) 
                {
                    movable = false;
                    gameObject.transform.position -= new Vector3 (0,-0.6f,0);
                   // RegisterBlock();
                    gameLogic.SpawnBlock();
                }    
                //Debug.Log(gameObject.transform.position);
            }
            else if(time > GameLogic.falltime)
            {
                gameObject.transform.position += new Vector3 (0,-0.6f,0);
                time = 0;
                if(!ValidMove()) 
                {
                    movable = false;
                    gameObject.transform.position -= new Vector3 (0,-0.6f,0);
                    //RegisterBlock();
                    gameLogic.SpawnBlock();
                }    
                //Debug.Log(gameObject.transform.position);
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                gameObject.transform.position += new Vector3 (-0.6f,0,0);
                if(!ValidMove()) 
                    gameObject.transform.position -= new Vector3 (-0.6f,0,0);
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                gameObject.transform.position += new Vector3 (0.6f,0,0);
                if(!ValidMove())
                    gameObject.transform.position -= new Vector3 (0.6f,0,0);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //rotate !
                rig.transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), -90);
                if(!ValidMove())
                    rig.transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), 90);
            }
        }
    }
    /*void RegisterBlock()
    {
        foreach(Transform subBlock in rig.transform)
        {
            gameLogic.grid[Mathf.RoundToInt(subBlock.position.x), Mathf.RoundToInt(subBlock.position.y)] = subBlock;
        }
    }*/
    bool ValidMove()
    {
        foreach(Transform subBlock in rig.transform)
        {
            if( subBlock.transform.position.x < 0 ||
                subBlock.transform.position.x >= GameLogic.width ||
                subBlock.transform.position.y < 0 )
            {
                print(subBlock.name);
                Debug.Log(subBlock.transform.position.x);
                Debug.Log(subBlock.transform.position.y);
                return false;
            }
            /*if(gameLogic.grid[Mathf.RoundToInt(subBlock.position.x), Mathf.RoundToInt(subBlock.position.y)] != null)
            {
                return false;
            }*/
        }
        return true;
    }
    /*void leftclick()
    {
        gameObject.transform.position += new Vector3 (-0.6f,0,0);
        if(ValidMove() == false) 
            gameObject.transform.position -= new Vector3 (-0.6f,0,0);
    }
    void rightclick()
    {
        gameObject.transform.position += new Vector3 (0.6f,0,0);
        if(ValidMove() == false)
            gameObject.transform.position -= new Vector3 (0.6f,0,0);
    }
    void turnclick()
    {
        rig.transform.eulerAngles += new Vector3(0,0,90);
        if(ValidMove() == false)
            rig.transform.eulerAngles -= new Vector3(0,0,90);
    }
    void downclick()
    {
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
    }*/
}