using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
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
        if (Input.GetKeyDown(KeyCode.W))
    {
        Sprite_Renderer.sprite = SpriteTexture[1];
    }
    if (Input.GetKeyUp(KeyCode.W))
    {
        Sprite_Renderer.sprite = SpriteTexture[0];
        Thread.Sleep(150); 
        SceneManager.LoadScene("Scenes/SampleScene");
    }
    /*if (Input.touches[0] == TouchPhase.Began ){

        }
        
    }
    if (Input.touches[0] == TouchPhase.Ended ){
            
        }
    }*/
    }
}
