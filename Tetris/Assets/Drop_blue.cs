﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_blue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += new Vector3(0,-2.5f,0) * Time.deltaTime;
    }
}
