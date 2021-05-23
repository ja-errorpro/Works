using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreComputing : MonoBehaviour
{
    
    static public class ScoreData
    {

        public static int lines=0;
        public static int all_deleted_lines = 0;
        public static int Score = 0;
        public static Text ScoreText;
    }
    void Start()
    {
        ScoreData.ScoreText = GameObject.Find("Canvas/PlayingUIShow/ScoreText").GetComponent<Text>();
    }

    public static void Update()
    {
        if (ScoreData.lines == 1)
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
            ScoreData.Score += ScoreData.lines * 10;
            ScoreData.ScoreText.text = "" + ScoreData.Score;
        }
        else if (ScoreData.lines >= 4)
        {
            ScoreData.Score += ScoreData.lines * 10;
            ScoreData.ScoreText.text = "" + ScoreData.Score;
        }
    }
}
