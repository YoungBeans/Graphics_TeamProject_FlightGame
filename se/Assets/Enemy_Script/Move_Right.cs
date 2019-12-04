using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Right : MonoBehaviour
{
    public float CharactorMoveSpeed = 90f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.UpArrow)){ 
        this.transform.Translate(new Vector3(-1, -1, 0) * CharactorMoveSpeed * Time.deltaTime);
        //}
    }
}
