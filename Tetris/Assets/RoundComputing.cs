using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundComputing : MonoBehaviour
{
    public static int Round;
    public Text RoundText;
    // Start is called before the first frame update
    void Start()
    {
        RoundText = GameObject.Find("Canvas/ContinueShow/RoundText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Round = TimeControl.minutes + 1;
        RoundText.text = "" + Round;
    }
}