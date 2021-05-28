using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreComputing : MonoBehaviour
{
    
    static public class ScoreData
    {

        public static int lines=0;
        public static int all_deleted_lines = 0; // 紀錄已刪除行數
        public static int Score = 0;
        public static Text ScoreText;
    }
    void Start()
    {
        ScoreData.ScoreText = GameObject.Find("Canvas/PlayingUIShow/ScoreText").GetComponent<Text>(); // 尋找顯示之UI Text 
    }

    public static void Update()
    {
        if (ScoreData.lines == 1) // 依據消除行數計分
        {
            ScoreData.Score += ScoreData.lines * 10;
            ScoreData.ScoreText.text = "" + ScoreData.Score;
        }
        else if(ScoreData.lines == 2)
        {
            ScoreData.Score += ScoreData.lines * 10;
            ScoreData.ScoreText.text = "" + ScoreData.Score;
        }
        else if (ScoreData.lines == 3)
        {
            ScoreData.Score += ScoreData.lines * 15;
            ScoreData.ScoreText.text = "" + ScoreData.Score;
        }
        else if (ScoreData.lines >= 4)
        {
            ScoreData.Score += ScoreData.lines * 20;
            ScoreData.ScoreText.text = "" + ScoreData.Score;
        }
    }
}
