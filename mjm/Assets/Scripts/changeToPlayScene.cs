using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeToPlayScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("space"))
        {
            SceneManager.LoadScene("playGame");
        }
    }

    public void ChangeToPlayScene() 
    {

        SceneManager.LoadScene("playGame");
    }
}
