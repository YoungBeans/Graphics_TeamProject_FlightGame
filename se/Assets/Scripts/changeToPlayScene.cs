using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeToPlayScene : MonoBehaviour
{
    public Camera[] camArr;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int t = 1;
        for (int i = 0; i < 3; i++)
        {
            if (camArr[i].enabled == true)
            {
                t = i;
                break;
            }
        }

        if (Input.GetKeyUp("space"))
        {
            switch (t)
            {
                case 0:
                    SceneManager.LoadScene("playGameWhite");
                    break;
                case 1:
                    SceneManager.LoadScene("playGameRed");
                    break;
                case 2:
                    SceneManager.LoadScene("playGameBlack");
                    break;
                default:
                    break;
            }
        }
    }
}
