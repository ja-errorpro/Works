using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOGO : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
    {
        transform.Translate(Vector2.left * Time.deltaTime); //往左
    }
    if (Input.GetKey(KeyCode.RightArrow))
     {
       transform.Translate(Vector2.right * Time.deltaTime); //往右
    }
    if (Input.GetKey(KeyCode.UpArrow)) 
    {
        transform.Translate(Vector2.up * Time.deltaTime); //往上
    }
    if (Input.GetKey(KeyCode.DownArrow))
    {
        transform.Translate(Vector2.down * Time.deltaTime); //往下
    }

    }
}
