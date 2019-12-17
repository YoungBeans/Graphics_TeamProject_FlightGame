using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public float LimitTime;
    public Text text_Timer = GameObject.Find("Time").GetComponent<Text>();

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        LimitTime -= Time.deltaTime;
        text_Timer.text = "시간 : " + Mathf.Round(LimitTime);
    }
}



