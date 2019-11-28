using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class cameraLookAt : MonoBehaviour
{
    public Camera[] camArr;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int t = 0;

        for (int i = 0; i < 3; i++)
        {
            if (camArr[i].enabled == true)
            {
                t = i;
                break;
            }
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) == true)
        {
            camArr[t].enabled = false;
            camArr[(t + 1) % 3].enabled = true;
            camArr[(t + 2) % 3].enabled = false;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) == true)
        {
            camArr[t].enabled = false;
            camArr[(t + 1) % 3].enabled = false;
            camArr[(t + 2) % 3].enabled = true;
        }
    }
}




