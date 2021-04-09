using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }
}
