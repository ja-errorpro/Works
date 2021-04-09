using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    // Start is called before the first frame update
    float time, startTime;
    Text timer;

    void Start(){
	    timer = GameObject.Find("Canvas/Text").GetComponent<Text>();
	    startTime=Time.time;

    }

    void Update(){
	    time=Time.time-startTime;
	
	    int seconds = (int)(time%60);
	    int minutes = (int)(time/60);

	    string startime = string.Format("{0:00}:{1:00}",minutes,seconds);
	    timer.text = startime;
    }
}
