using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sport : MonoBehaviour
{
    public Vector3 rotationPoint; //決定旋轉點，避免方塊出現旋轉之情形
    private float lastfall;
    public float falltime; // 掉落速度
    public static bool CanMove = true; // 是否可移動
    public static bool Leftclick = false; // 判定是否按下按鈕
    public static bool Rightclick = false;
    public static bool Upclick = false;
    public static bool Downclick = false;
    void Start()
    {
        if(!isvalidgridpos()) // 方塊生成後，是否於界內
        {
            UI_Controller.ifGameover = true; // 是，執行GameOver
            CanMove = false; // 結束操作
        }
    }
    void Update()
    {
        if(CanMove == true) // 暫停時的判定，暫停時不可進行操作
        {
            falltime = 0.4f / (RoundComputing.Round);// 速度隨關卡增加而加速

            if(Input.GetKeyDown(KeyCode.LeftArrow) || Leftclick == true) // Left 
            {
            
                transform.position += new Vector3(-1, 0, 0);
                if(isvalidgridpos()) // 判定是否在界內
                {
                    updategrid();// 是， 紀錄方塊位置
                }
                else
                {
                    transform.position += new Vector3(1, 0, 0); // 否 ， 執行反操作
                }
                Leftclick = false; // 按下左按鈕後只執行一次移動。
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Rightclick == true)// Right 
            {

                transform.position += new Vector3(1, 0, 0);
                if (isvalidgridpos())// 判定是否在界內
                {
                    updategrid();// 是， 紀錄方塊位置
                }
                else
                {
                    transform.position += new Vector3(-1, 0, 0); // 否 ， 執行反操作
                }
                Rightclick = false; // 按下右按鈕後只執行一次移動。
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Upclick == true)// Rotate 
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint) , new Vector3(0,0,1) , 90);

                if (isvalidgridpos())// 判定是否在界內
                {
                    updategrid();// 是， 紀錄方塊位置
                }
                else
               {
                    transform.RotateAround(transform.TransformPoint(rotationPoint) , new Vector3(0,0,1) , -90);// 否 ， 執行反操作
                }
                Upclick = false;// 按下上按鈕後只執行一次移動。
            }
            if (Time.time - lastfall > ((Input.GetKey(KeyCode.DownArrow) || Downclick == true) ? falltime / 10 : falltime)) // 加速 、 掉落
            {
                transform.position += new Vector3(0, -1, 0);
                if (isvalidgridpos())// 判定是否在界內
                {
                    updategrid();// 是， 紀錄方塊位置
                }
                else
                {
                    transform.position += new Vector3(0, 1, 0);// 否 ， 執行反操作

                    Invoke("DelayDown",0.05f); // 落地時 ， 延遲可繼續操作
                }
                lastfall = Time.time; // 更新
            }
        }
    }

    bool isvalidgridpos()// 使用向量判定每個方塊位置是否於界內
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

    void updategrid() // 將方塊位置紀錄於 grid 矩陣中
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
    void CheckLine() // 逐行檢查，進行計分
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

    bool HasLine(int i) // 逐行檢查是否有滿行，回傳
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

    void DeleteLine(int i) // 刪除行
    {
        for(int j = 0 ; j < Grid.w ; j++)
        {
            Destroy(Grid.grid[j, i].gameObject);
            Grid.grid[j, i] = null;
        }
    }

    void RowDown(int i) // 刪除行後將上方方塊掉落
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
    void DelayDown() // 延遲執行
    {
        enabled = false; // 不可進行操作
        CheckLine(); // 檢查
        FindObjectOfType<GameLogic>().SpawnBlock(); // 隨機生成方塊
        FindObjectOfType<prestop>().stop(); // 隨機生成方塊
        FindObjectOfType<presport>().PreSpawnBlock(); // 隨機生成方塊
        CancelInvoke("DelayDown"); // 結束延遲
    }
}