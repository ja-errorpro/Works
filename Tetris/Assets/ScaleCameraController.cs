using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCameraController : MonoBehaviour
{
    public float aspectRatio = 9f / 16f; // 螢幕比例
    void Start()
    {
        Camera cam = GetComponent<Camera>();
        //裝置螢幕的長寬比
        float screenRatio = (float)Screen.width / (float)Screen.height;

        //裝置螢幕長寬比和目標長寬比的比值
        float scale = screenRatio / aspectRatio;

        //(Camera高度維持  寬度縮小)
        if(scale > 1f)
        {
            Rect pixRect = cam.pixelRect;

            pixRect.width = pixRect.height * aspectRatio;
            pixRect.y = 0f;

            pixRect.x = ((float)Screen.width - pixRect.width) / 2f;

            cam.pixelRect = pixRect;
        }
        else //(Camera寬度維持  高度縮小)
        {
            Rect pixRect = cam.pixelRect;

            pixRect.height = pixRect.width / aspectRatio;
            pixRect.x = 0f;

            pixRect.y = ((float)Screen.height - pixRect.height) / 2f;
            
            cam.pixelRect = pixRect;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
