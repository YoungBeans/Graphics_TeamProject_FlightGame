using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_Move : MonoBehaviour
{
    public float speed = 20.0f;         //회전속도
    // Update is called once per frame
    void Update()
    {
        // 매 프레임마다 메소드 호출
        Move();
    }

    // 움직이는 기능을 하는 메소드
    private void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))  // → 방향키를 누를 때
        {
            if(gameObject.transform.rotation.z > -0.5f)
                transform.Rotate(new Vector3(0, 0, -speed * Time.deltaTime));
            //transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))  // ← 방향키를 누를 때
        {
            if (gameObject.transform.rotation.z < 0.5f)
                transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
            //transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
        else if (gameObject.transform.rotation.z != 0.0f)
        {
            if (gameObject.transform.rotation.z < 0.0f)
                transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
            else
                transform.Rotate(new Vector3(0, 0, - speed * Time.deltaTime));

        }

    }
}
