using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sport : MonoBehaviour
{
    private float lastfall;
    public float falltime;
    public static bool CanMove = true;
    public static bool Leftclick = false;
    public static bool Rightclick = false;
    public static bool Upclick = false;
    public static bool Downclick = false;
    void Start()
    {
        if(!isvalidgridpos())
        {
            UI_Controller.ifGameover = true;
            CanMove = false;
        }
    }
    void Update()
    {
        if(CanMove == true)
        {
            falltime = 0.4f / (RoundComputing.Round);

            if(Input.GetKeyDown(KeyCode.LeftArrow) || Leftclick == true)
            {
            
                transform.position += new Vector3(-1, 0, 0);
                if(isvalidgridpos())
                {
                    updategrid();
                }
                else
                {
                    transform.position += new Vector3(1, 0, 0);
                }
                Leftclick = false;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Rightclick == true)
            {

                transform.position += new Vector3(1, 0, 0);
                if (isvalidgridpos())
                {
                    updategrid();
                }
                else
                {
                    transform.position += new Vector3(-1, 0, 0);
                }
                Rightclick = false;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Upclick == true)
            {
                transform.Rotate(0, 0, -90);

                if (isvalidgridpos())
                {
                    updategrid();
                }
                else
               {
                    transform.Rotate(0, 0, 90);
                }
                Upclick = false;
            }
            if (Time.time - lastfall > ((Input.GetKey(KeyCode.DownArrow) || Downclick == true) ? falltime / 10 : falltime))
            {
                transform.position += new Vector3(0, -1, 0);
                if (isvalidgridpos())
                {
                    updategrid();
                }
                else
                {
                    transform.position += new Vector3(0, 1, 0);

                    Invoke("DelayDown",0.2f);
                }
                lastfall = Time.time;
            }
        }
    }

    bool isvalidgridpos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = Grid.roundvec2(child.position);
            if (!Grid.insideborder(v))
            {
                return false;
            }

            if (Grid.grid[(int)v.x, (int)v.y] != null && Grid.grid[(int)v.x, (int)v.y].parent != transform)
            {
                return false;
            }
        }
        return true;
    }

    void updategrid()
    {
        for (int y = 0; y < Grid.h; y++)
            for (int x = 0; x < Grid.w; x++)
            {
                if (Grid.grid[x, y] != null)
                    if (Grid.grid[x, y].parent == transform)
                        Grid.grid[x, y] = null;
            }
        
        foreach (Transform child in transform)
        {
            Vector2 v = Grid.roundvec2(child.position);
            Grid.grid[(int)v.x, (int)v.y] = child;
        }
    }
    void CheckLine()
    {
        ScoreComputing.ScoreData.lines = 0;
        for(int i = Grid.h - 1 ; i >= 0 ; i--)
        {
            if(HasLine(i))
            {
                DeleteLine(i);
                ScoreComputing.ScoreData.lines++;
                RowDown(i);
            }
        }
        ScoreComputing.ScoreData.all_deleted_lines += ScoreComputing.ScoreData.lines;
       // Debug.Log(ScoreComputing.GameData.lines);
    }

    bool HasLine(int i)
    {
        for(int j = 0 ; j < Grid.w ; j++)
        {
            if(Grid.grid[j, i] == null)
            {
                return false;
            }
        }
        return true;
    }

    void DeleteLine(int i)
    {
        for(int j = 0 ; j < Grid.w ; j++)
        {
            Destroy(Grid.grid[j, i].gameObject);
            Grid.grid[j, i] = null;
        }
    }

    void RowDown(int i)
    {
        for(int y = i ; y < Grid.h ; y++)
        {
            for(int j = 0 ; j < Grid.w ; j++)
            {
                if(Grid.grid[j, y] != null)
                {
                    Grid.grid[j, y - 1] = Grid.grid[j, y];
                    Grid.grid[j, y] = null;
                    Grid.grid[j, y - 1].transform.position -= new Vector3(0,1,0);
                }

            }
        }
    }
    void DelayDown()
    {
        enabled = false;
        CheckLine();
        FindObjectOfType<GameLogic>().SpawnBlock();
        CancelInvoke("DelayDown");
    }
    void PressLeft()
    {
        if(CanMove == true)
        {
            transform.position += new Vector3(-1, 0, 0);
            if(isvalidgridpos())
            {
                updategrid();
            }
            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
    }
}