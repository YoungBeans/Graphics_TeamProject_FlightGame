using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public static int score;
    public Text text = GameObject.Find("score").GetComponent<Text>();

    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score;
    }
}
