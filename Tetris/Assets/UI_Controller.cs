using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UI_Controller : MonoBehaviour
{
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
}
    
    

