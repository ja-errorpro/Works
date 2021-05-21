using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UI_Controller : MonoBehaviour
{
    public GameObject outgameMenu;
    public GameObject PlayingGameObject;
    public GameObject ingameMenu;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
      
    }
    public void click()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
    public void OnPause()//Stop
    {
        Time.timeScale = 0;
        outgameMenu.SetActive(true);
        PlayingGameObject.SetActive(false);
        ingameMenu.SetActive(false);
        sport.CanMove = false;
    }

    public void OnResume()//Continue
    {
        Time.timeScale = 1f;
        outgameMenu.SetActive(false);
        PlayingGameObject.SetActive(true);
        ingameMenu.SetActive(true);
        sport.CanMove = true;
    }

    public void OnRestart()//Restart
    {
        //Loading SampleScene
        SceneManager.LoadScene("Scenes/SampleScene");
        Time.timeScale = 1f;
        sport.CanMove = true;
    }
}
    
    

