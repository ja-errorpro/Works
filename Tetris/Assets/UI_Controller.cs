using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UI_Controller : MonoBehaviour
{
    public Sprite[] SpriteTexture = new Sprite[2];
    private SpriteRenderer Sprite_Renderer;
    Vector2 m_screenPos = new Vector2();
    void Start()
    {
        Sprite_Renderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (Input.GetKeyDown(KeyCode.W))
    {
        Sprite_Renderer.sprite = SpriteTexture[1];
    }
    if (Input.GetKeyUp(KeyCode.W))
    {
        Sprite_Renderer.sprite = SpriteTexture[0];
        Thread.Sleep(150); 
        SceneManager.LoadScene("Scenes/SampleScene");
    }*/
    /*if (Input.touches[0] == TouchPhase.Began ){
        Sprite_Renderer.sprite = SpriteTexture[1];
    }
    if (Input.touches[0] == TouchPhase.Ended ){
        Sprite_Renderer.sprite = SpriteTexture[0];
        Thread.Sleep(150); 
        SceneManager.LoadScene("Scenes/SampleScene");
    }*/
    /*if(Input.touchCount == 1){
        Touch touch = Input.GetTouch(0);
        bool isTouchSTART = EventSystem.current.IsPointerOverGameObject(touch.fingerId);
        if(isTouchSTART){
            switch(touch.phase){
                case TouchPhase.Began:
                    Sprite_Renderer.sprite = SpriteTexture[1];
                    break;
                case TouchPhase.Ended:
                    Sprite_Renderer.sprite = SpriteTexture[0];
                    Thread.Sleep(150); 
                    SceneManager.LoadScene("Scenes/SampleScene");
                    break;
            }
        }
    }*/

    }
    public void click(){
        Sprite_Renderer.sprite = SpriteTexture[1]; 
    }
    /*public void clickExit(){
        Sprite_Renderer.sprite = SpriteTexture[0];
        Thread.Sleep(150); 
        SceneManager.LoadScene("Scenes/SampleScene");
    }*/
}
    
    

