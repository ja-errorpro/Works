using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UI_Controller : MonoBehaviour
{
    public GameObject PauseMenu; // 暫停時顯示之UI
    public GameObject PlayingobjectMenu; // 遊戲時顯示之物件
    public GameObject PlayingUIMenu; // 遊戲時顯示UI
    public GameObject GameoverMenu; // 結束時顯示
    public static bool ifGameover = false; // 是否結束
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        OnGameover(); // 時時檢查是否結束
    }
    public void click()
    {
        SceneManager.LoadScene("Scenes/SampleScene"); // 切入遊戲場景
    }
    public void OnPause()//Stop
    {
        Time.timeScale = 0; // 暫停
        PauseMenu.SetActive(true);
        PlayingobjectMenu.SetActive(false);
        PlayingUIMenu.SetActive(false);
        GameoverMenu.SetActive(false);
        sport.CanMove = false;// 不可操作
    }

    public void OnResume()//Continue
    {
        Time.timeScale = 1f; // 遊戲正常速度執行
        PauseMenu.SetActive(false);
        PlayingobjectMenu.SetActive(true);
        PlayingUIMenu.SetActive(true);
        GameoverMenu.SetActive(false);
        sport.CanMove = true;// 可操作
    }

    public void OnRestart()//Restart
    {
        //Loading SampleScene
        SceneManager.LoadScene("Scenes/SampleScene"); // 重新進入遊戲場景
        Debug.Log("Reatart");
        Time.timeScale = 1f;
        sport.CanMove = true;
    }
    public void OnGameover()//Gameover
    {
        if(ifGameover == true)
        {
            Debug.Log("GameOver");
            Time.timeScale = 0;
            PauseMenu.SetActive(false);
            PlayingobjectMenu.SetActive(false);
            PlayingUIMenu.SetActive(false);
            GameoverMenu.SetActive(true);
            ifGameover = false; // 只須執行一次
        }
    }
    public void PressLeft() // Left
    {
        if(sport.CanMove == true)//是否可操作
        {
            sport.Leftclick = true;
        }
    }
    public void PressRight() // Rught
    {
        if(sport.CanMove == true)
        {
            sport.Rightclick = true;
        }
    }
    public void PressUp() // Rotate
    {
        if(sport.CanMove == true)
        {
            sport.Upclick = true;
        }
    }
    public void DownclickTrue() // 按下時執行
    {
        sport.Downclick = true;
    }
    public void DownclickFalse() // 放開時執行
    {
        sport.Downclick = false;
    }
}
    
    

