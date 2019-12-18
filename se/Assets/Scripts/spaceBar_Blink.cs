using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class spaceBar_Blink : MonoBehaviour
{
    public Text flashingText;

    void Start()
    {
        flashingText = GameObject.Find("Text").GetComponent<Text>();
        StartCoroutine(BlinkText());
    }

    public IEnumerator BlinkText()
    {
        while (true)
        {
            flashingText.text = "";
            yield return new WaitForSeconds(.5f);
            flashingText.text = "Click to SpaceBar";
            yield return new WaitForSeconds(.5f);
        }
    }
}
