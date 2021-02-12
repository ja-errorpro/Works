using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sport : MonoBehaviour
{
    float lastfall=0;
    void Start()
    {
        if(!isvalidgridpos())
        {
            Debug.Log("Gameover");
            Destroy(gameObject);
        }
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
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
        else if (Input.GetKeyDown(KeyCode.RightArrow))
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
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
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
        }
        if (Input.GetKey(KeyCode.DownArrow)||Time.time - lastfall>=1)
        {
            transform.position += new Vector3(0, -1, 0);
            
            if (isvalidgridpos())
            {
                updategrid();
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);

                FindObjectOfType<GameLogic>().SpawnBlock();
                enabled = false;
            }

            lastfall = Time.time;
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
        //加入更新數據
        foreach (Transform child in transform)
        {
            Vector2 v = Grid.roundvec2(child.position);
            Grid.grid[(int)v.x, (int)v.y] = child;
        }
    }
}
