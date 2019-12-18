using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float LimitTime;
    public Text text_Timer;

    void Start()
    {
        text_Timer = GameObject.Find("Timer").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        LimitTime -= Time.deltaTime;
        text_Timer.text = "시간 : " + Mathf.Round(LimitTime);
    }
}



