using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Down : MonoBehaviour
{
    public float CharactorMoveSpeed = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.UpArrow)){ 
            this.transform.Translate(new Vector3(0, -1, 0) * CharactorMoveSpeed *Time.deltaTime);
            this.transform.Rotate(new Vector3(0, 20.0f * Time.deltaTime, 0));

        //}
    }
}
