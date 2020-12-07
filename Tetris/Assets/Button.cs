using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Button : MonoBehaviour
{
    // Start is called before the first frame update
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
       
    }
    public void Onclick(){
        Sprite_Renderer.sprite = SpriteTexture[1]; 
    }
}
