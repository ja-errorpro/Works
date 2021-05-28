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
	    TimeText = GameObject.Find("Canvas/PlayingUIShow/TimeText").GetComponent<Text>(); // 找尋顯示之UI Text
	    startTime = Time.time; // 紀錄開始時間

    }

    void Update(){
	    time = Time.time - startTime; //紀錄目前為止之時間
	
	    seconds = (int)(time%60);
	    minutes = (int)(time/60);

	    string startime = string.Format("{0:00}:{1:00}", minutes, seconds); // 顯示
	    TimeText.text = startime;
    }
}
