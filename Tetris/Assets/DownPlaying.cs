using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownPlaying : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void DownclickTrue()
    {
        sport.Downclick = true;
        Debug.Log("True");
    }
    public void DownclickFalse()
    {
        sport.Downclick = false;
        Debug.Log("False"); 
    }
}