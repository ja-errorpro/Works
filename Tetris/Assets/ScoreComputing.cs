using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
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
=======

public class ScoreComputing : MonoBehaviour
{
    static public class GameData
    {

        public static int lines=0;
        public static int all_deleted_lines = 0;
        public static int score = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public static void Update()
    {
        if (GameData.lines == 1)
        {
            Debug.Log("+1");
        }
        else if(GameData.lines == 2)
        {
            Debug.Log("+2");
        }
        else if (GameData.lines == 3)
        {
            Debug.Log("+3");
        }
        else if (GameData.lines >= 4)
        {
            Debug.Log("+4++");
>>>>>>> a9b4de8e48df11627b822bb16c2f1fd9368bd724
        }
    }
}
