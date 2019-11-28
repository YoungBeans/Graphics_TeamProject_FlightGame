using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoRotate : MonoBehaviour
{
    public float speed = 10.0f;         //회전속도
    private void Update()
    {
        Orbit_Rotation();
    }

    void Orbit_Rotation()
    {
        transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
    }
}
