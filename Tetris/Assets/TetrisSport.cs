using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TetrisSport : MonoBehaviour
{    
    bool movable = true;
    public static float time = 0;
    public GameObject rig;
    public Transform[,] grid = new Transform[width,height];//儲存有方塊的位置
    private float quickfalltime = 0.05f;
    public  float falltime = 0.5f;
    public static int height = 23;//因為掉落的初始位置(Spawn)在(5,21)，避免grid陣列超出範圍
    public static int width = 10;
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
                transform.position += new Vector3 (0,-1,0);
                time = 0;
                if(!ValidMove()) 
                {
                    movable = false;
                    transform.position -= new Vector3 (0,-1,0);
                    RegisterBlock();
                    CheckLine();
                    FindObjectOfType<GameLogic>().SpawnBlock();
                }    
                //Debug.Log(gameObject.transform.position);
            }
            else if(time > falltime)
            {
                transform.position += new Vector3 (0,-1,0);
                time = 0;
                if(!ValidMove())
                {
                    movable = false;
                    transform.position -= new Vector3 (0,-1,0);
                    RegisterBlock();
                    CheckLine();
                    FindObjectOfType<GameLogic>().SpawnBlock();
                }    
                //Debug.Log(gameObject.transform.position);
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position += new Vector3 (-1,0,0);
                if(!ValidMove()) 
                    transform.position -= new Vector3 (-1,0,0);
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position += new Vector3 (1,0,0);
                if(!ValidMove())
                    transform.position -= new Vector3 (1,0,0);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //rotate !
                transform.Rotate(0,0,-90);//rig.transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), -90);
                if(!ValidMove())
                    transform.Rotate(0,0,90);//rig.transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), 90);
            }
        }
    }
    void CheckLine()
    {
        for(int i = height-1 ; i >= 0 ; i--)
        {
            if(HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }
    bool HasLine(int i)
    {
        for(int j = 0 ; j < width ; j++)
        {
            if(grid[j,i] == null)
            {
                return false;
            }
        }
        Debug.Log("HasLine");
        return true;
    }
    void DeleteLine(int i)
    {
        for(int j = 0 ; j < width ; j++)
        {
            Destroy(grid[j,i].gameObject);
            grid[j,i] = null;
        }
    }
    void RowDown(int i)
    {
        for(int y = i ; y < height ; y++)
        {
            for(int j = 0 ; j < width ; j++)
            {
                if(grid[j,y] != null)
                {
                    grid[j,y-1] = grid[j,y];
                    grid[j,y] = null;
                    grid[j,y-1].transform.position -= new Vector3(0,1,0);
                }
            }
        }
    }
    void RegisterBlock()
    {
        foreach(Transform subBlock in rig.transform)
        {
            int roundX = Mathf.RoundToInt(subBlock.transform.position.x);
            int roundY = Mathf.RoundToInt(subBlock.transform.position.y);
            grid[roundX , roundY] = subBlock;//在每個方塊的(x,y)儲存
            /*Debug.Log(roundX);
            Debug.Log(roundY);*/
        }
    }
    bool ValidMove()
    {
        foreach(Transform subBlock in rig.transform)
        {
            int roundX = Mathf.RoundToInt(subBlock.transform.position.x);
            int roundY = Mathf.RoundToInt(subBlock.transform.position.y);

            if( roundX < 0 || roundX >= width || roundY < 0 )
            {
                /*print(subBlock.name);
                Debug.Log(roundX);
                Debug.Log(roundY);*/
                return false;
            }

            if(grid[roundX, roundY] != null)
            {
                Debug.Log("False!");
                return false;
            } 
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