using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    // Start is called before the first frame update
        public float time, startTime;
        public int seconds;
	    public static int minutes ;
        public Text TimeText;
    void Start(){
	    TimeText = GameObject.Find("Canvas/PlayingUIShow/TimeText").GetComponent<Text>();
	    startTime = Time.time;

    }

    void Update(){
	    time = Time.time - startTime;
	
	    seconds = (int)(time%60);
	    minutes = (int)(time/60);

	    string startime = string.Format("{0:00}:{1:00}", minutes, seconds);
	    TimeText.text = startime;
    }
}
