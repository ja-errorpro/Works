using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UI_Controller : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject PlayingobjectMenu;
    public GameObject PlayingUIMenu;
    public GameObject GameoverMenu;
    public static bool ifGameover = false;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        OnGameover();
    }
    public void click()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
    public void OnPause()//Stop
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
        PlayingobjectMenu.SetActive(false);
        PlayingUIMenu.SetActive(false);
        GameoverMenu.SetActive(false);
        sport.CanMove = false;
    }

    public void OnResume()//Continue
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        PlayingobjectMenu.SetActive(true);
        PlayingUIMenu.SetActive(true);
        GameoverMenu.SetActive(false);
        sport.CanMove = true;
    }

    public void OnRestart()//Restart
    {
        //Loading SampleScene
        SceneManager.LoadScene("Scenes/SampleScene");
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
            ifGameover = false;
        }
    }
    public void PressLeft()
    {
        if(sport.CanMove == true)
        {
            sport.Leftclick = true;
        }
    }
    public void PressRight()
    {
        if(sport.CanMove == true)
        {
            sport.Rightclick = true;
        }
    }
    public void PressUp()
    {
        if(sport.CanMove == true)
        {
            sport.Upclick = true;
        }
    }
    public void DownclickTrue()
    {
        sport.Downclick = true;
    }
    public void DownclickFalse()
    {
        sport.Downclick = false;
    }
}
    
    

