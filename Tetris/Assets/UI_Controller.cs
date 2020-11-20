using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public Sprite[] SpriteTexture = new Sprite[2];
    private SpriteRenderer Sprite_Renderer;
    void Start()
    {
        Sprite_Renderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMobileEnter(){
        Sprite_Renderer.sprite = SpriteTexture[1];
    }
    void OnMobileExit(){
        Sprite_Renderer.sprite = SpriteTexture[0];
    }
}
